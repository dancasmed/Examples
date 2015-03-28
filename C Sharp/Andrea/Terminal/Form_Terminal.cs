using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Terminal
{
    public partial class Form_Terminal : Form
    {
        Term terminal;
            
        public Form_Terminal()
        {
            InitializeComponent();
            terminal = new Term();
            terminal.Start(textBox_Input, textBox_Output);
            Anndrea.Brain.Get_Main_Brain().Start(terminal);
        }

        private void textBox_Input_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 10 || e.KeyChar == 13)
            {
                e.Handled = true;
                terminal.Get_Command(textBox_Input.Text);
                textBox_Input.Text = "";
            }
        }

        private void Form_Terminal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Anndrea.Brain.Get_Main_Brain().Stop();
        }
    }
}
