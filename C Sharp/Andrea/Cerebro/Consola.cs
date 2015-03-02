using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cerebro
{
    public class Consola
    {
        TextBox m_input;
        TextBox m_output;

        public void Iniciar(TextBox input, TextBox output)
        {
            m_input = input;
            m_output = output;
            println("Consola iniciada.");

        }

        internal void println(string str)
        {
            m_output.Text += str + Environment.NewLine;
        }

        public void Obten_Comando(string str)
        {
            println("> " + str);
            Cerebro.Procesa_Texto(str);
        }
    }
}
