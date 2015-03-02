using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cerebro;

namespace Consola
{
    public partial class Form_Consola : Form
    {
        Cerebro.Consola consola;
        

        public Form_Consola()
        {
            InitializeComponent();
            consola = new Cerebro.Consola();
            consola.Iniciar(textBox_input, textBox_output);
            Cerebro.Cerebro.Iniciar(consola);
        }

        private void Form_Consola_Load(object sender, EventArgs e)
        {

        }

        private void textBox_input_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 10 || e.KeyChar == 13)
            {
                e.Handled = true;
                consola.Obten_Comando(textBox_input.Text);
                textBox_input.Text = "";
            }
        }


        
    }
}
