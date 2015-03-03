using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brain
{
    public static class Brain
    {
        static internal Terminal terminal;
        static internal Vision vision;
        static internal bool show_vision = false;
        static public void Start(Terminal c)
        {
            terminal = c;
            vision = new Vision();
            vision.Iniciar();
            terminal.println("INFO: Brain started."+Environment.NewLine);
            terminal.println("Artificial Neural Network Dynamicly Redesigned (Entidad Artificial) Version beta.");
            terminal.println("Official repository: https://github.com/dancasmed/Examples/tree/master/C%20Sharp/Andrea" + Environment.NewLine);
            terminal.println("Created by Daniel Castro  dancasmed@gmail.com" + Environment.NewLine);
            terminal.println("Available commands:");
            terminal.println("show" + Environment.NewLine + Environment.NewLine);
        }
     
        static public void Procesa_Texto(string str)
        {
            string[] words = str.Split(' ');
            switch(words[0])
            {
                case "show":
                    if(words.Length<2)
                    {
                        Brain.terminal.println("Show what?");
                        Brain.terminal.println("Try: show <option>");
                        Brain.terminal.println("Options: vision, <person name>");
                    }
                    else
                    {
                        switch(words[1])
                        {
                            case "vision":
                                
                                show_vision = !show_vision;
                                vision.Show_Vision(show_vision);
                                break;
                            default:
                                int index = vision.recognized_people.IndexOf(words[1]);
                                if (index >= 0)
                                {
                                    Vision_Person_Name_Form person_form = new Vision_Person_Name_Form(index);
                                    person_form.Show();
                                }
                                else
                                {
                                    Brain.terminal.println("That person is no registered in the system.");
                                }
                                break;
                        }
                    }
                    break;
                default:
                    terminal.println("?");
                    break;
            }
            

        }
    }
}
