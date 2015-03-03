using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brain
{
    public class Terminal
    {
        TextBox m_Input;
        TextBox m_Output;

        public void Iniciar(TextBox input, TextBox output)
        {
            m_Input = input;
            m_Output = output;
            println("INFO: Terminal started.");

        }

        internal void println(string str)
        {
            m_Output.Text += str + Environment.NewLine;
        }

        public void Get_command(string str)
        {
            println("> " + str);
            Brain.Procesa_Texto(str);
        }
    }
}
