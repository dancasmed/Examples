using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Anndrea_Interfaces;

using Vision;
using Speech;

namespace Brain
{
    public class Brain
    {
        static Brain m_Brain = null;
        public static Brain Get_Main_Brain()
        {
            if(m_Brain == null)
            {
                m_Brain = new Brain();
            }
            return m_Brain;
        }

        internal ITerminal terminal;
        internal ISense m_Vision_Sense;
        internal bool m_Show_Vision_Sense = false;
        public bool Show_Vision_Sense
        {
            get
            {
                return m_Show_Vision_Sense;
            }
        }
        internal Voice voice;

        public void Start(ITerminal c)
        {
            terminal = c;

            m_Vision_Sense = Vision.Sense.Get_Sense();
            m_Vision_Sense.Start(c);
            voice = new Voice();
            voice.Start();

            terminal.PrintLn("INFO: Brain started."+Environment.NewLine);
            terminal.PrintLn("Artificial Neural Network Dynamicly Redesigned (Entidad Artificial) Version beta.");
            terminal.PrintLn("Official repository: https://github.com/dancasmed/Examples/tree/master/C%20Sharp/Andrea" + Environment.NewLine);
            terminal.PrintLn("Created by Daniel Castro  dancasmed@gmail.com" + Environment.NewLine);
            terminal.PrintLn("Available commands:");
            terminal.PrintLn("show" + Environment.NewLine + Environment.NewLine);

            voice.Speak("Hi, my name is Andrea.");
        }
     
        static public void Procesa_Texto(string str)
        {
            string[] words = str.Split(' ');
            switch(words[0])
            {
                case "show":
                    if(words.Length<2)
                    {
                        Brain.terminal.PrintLn("Show what?");
                        Brain.terminal.PrintLn("Try: show <option>");
                        Brain.terminal.PrintLn("Options: vision, <person name>");
                    }
                    else
                    {
                        switch(words[1])
                        {
                            case "vision":
                                
                                m_Show_Vision = !m_Show_Vision;
                                m_Vision_Sense.Show_Sense(m_Show_Vision);
                                
                                break;
                            default:
                               /* int index = vision.recognized_people.IndexOf(words[1]);
                                if (index >= 0)
                                {
                                    Vision_Person_Name_Form person_form = new Vision_Person_Name_Form(index);
                                    person_form.Show();
                                }
                                else
                                {
                                    Brain.terminal.PrintLn("That person is no registered in the system.");
                                }*/
                                break;
                        }
                    }
                    break;
                default:
                    terminal.PrintLn("?");
                    break;
            }
            

        }
    }
}
