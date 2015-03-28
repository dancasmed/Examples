using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Anndrea_Interfaces;
using Anndrea;

namespace Terminal
{
    public class Term : ITerminal
    {
        TextBox m_Input;
        RichTextBox m_Output;


        public void Start(TextBox input, RichTextBox output)
        {
            m_Input = input;
            m_Output = output;
            Express("Terminal started.", Expression_Types.Information);

        }

        public void Express(string str, Expression_Types type)
        {
            Color color = m_Output.ForeColor;
            int s_start = m_Output.TextLength;

            switch (type)
            {
                case Expression_Types.Error:
                    color = Color.IndianRed;
                    break;
                case Expression_Types.Information:
                    color = Color.CornflowerBlue;
                    break;
                case Expression_Types.Interaction:
                    color = Color.White;
                    break;
                case Expression_Types.Console:
                    color = Color.Gray;
                    break;
            }
            m_Output.AppendText(str + Environment.NewLine);
            m_Output.Select(s_start, str.Length);
            m_Output.SelectionColor = color;
            m_Output.SelectionStart = m_Output.TextLength;
            m_Output.ScrollToCaret();
        }

        public void Get_Command(string str)
        {
            Express("> " + str, Expression_Types.Console);
            Process_Command(str);
        }
        public void Process_Command(string str)
        {
            string[] words = str.Split(' ');
            switch (words[0])
            {
                case "show":
                    if (words.Length < 2)
                    {
                        Express("Show what?", Expression_Types.Console);
                        Express("Try: show <option>", Expression_Types.Console);
                        Express("Options: vision, <person name>", Expression_Types.Console);
                    }
                    else
                    {
                        switch (words[1])
                        {
                            case "vision":

                                Brain.Get_Main_Brain().Show_Vision_Sense();
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
                    Express("?", Expression_Types.Error);
                    break;
            }


        }
    }
}
