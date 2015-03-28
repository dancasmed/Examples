using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anndrea_Interfaces;

using Vision;
using Speech;

namespace Anndrea
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
        internal ISense m_Voice_Sense;

        List<ISense> m_Expresion_Senses;


        public Brain()
        {
            m_Expresion_Senses = new List<ISense>();
        }

        public void Start(ITerminal c)
        {
            terminal = c;

            m_Vision_Sense = Vision.Sense.Get_Sense();
            m_Vision_Sense.Start(c);
            m_Voice_Sense = Speech.Sense.Get_Sense();
            m_Voice_Sense.Start(c);

            m_Expresion_Senses.Add(m_Voice_Sense);

            terminal.Express("Brain started."+Environment.NewLine, Expression_Types.Information);
            terminal.Express("Artificial Neural Network Dynamicly Redesigned (Entidad Artificial) Version beta.", Expression_Types.Console);
            terminal.Express("Official repository: https://github.com/dancasmed/Examples/tree/master/C%20Sharp/Andrea" + Environment.NewLine, Expression_Types.Console);
            terminal.Express("Created by Daniel Castro  dancasmed@gmail.com" + Environment.NewLine, Expression_Types.Console);
            terminal.Express("Available commands:", Expression_Types.Console);
            terminal.Express("show" + Environment.NewLine + Environment.NewLine, Expression_Types.Console);

            Express("Hi, my name is Anndrea", Expression_Types.Interaction);
        }

        public void Stop()
        {
            m_Vision_Sense.Stop();
            m_Voice_Sense.Stop();
        }
     
        public void Procesa_Texto(string str)
        {
            string[] words = str.Split(' ');
            switch(words[0])
            {
                case "show":
                    if(words.Length<2)
                    {
                        terminal.Express("Show what?", Expression_Types.Information);
                        terminal.Express("Try: show <option>", Expression_Types.Information);
                        terminal.Express("Options: vision, <person name>", Expression_Types.Information);
                    }
                    else
                    {
                        switch(words[1])
                        {
                            case "vision":

                                m_Vision_Sense.Show_Sense(true);
                                
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
                    terminal.Express("?", Expression_Types.Information);
                    break;
            }
            

        }

        public void Express(string str, Expression_Types type)
        {
            foreach(ISense expression_sense in m_Expresion_Senses)
            {
                expression_sense.Express(str);
            }
            terminal.Express(str, Expression_Types.Interaction);
        }

        public void Show_Vision_Sense()
        {
            m_Vision_Sense.Show_Sense(true);
        }
    }
}
