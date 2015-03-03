using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Brain;

namespace Terminal
{
    public partial class Form_Terminal : Form
    {
        Brain.Terminal terminal;
            
        public Form_Terminal()
        {
            InitializeComponent();
            terminal = new Brain.Terminal();
            terminal.Iniciar(textBox_Input, textBox_Output);
            Brain.Brain.Start(terminal);
        }

        private void textBox_Input_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 10 || e.KeyChar == 13)
            {
                e.Handled = true;
                terminal.Get_command(textBox_Input.Text);
                textBox_Input.Text = "";
            }
        }
    }
}
