using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Brain
{
    public partial class Vision_Person_Name_Form : Form
    {
        int index = 0;
        public Vision_Person_Name_Form(int ind)
        {
            index = ind;
            InitializeComponent();
            textBox_Name.Text = Brain.vision.recognized_people[index];
            imageBox_Picture.Image = Brain.vision.recognized_faces[index];
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            Brain.vision.recognized_people[index] = textBox_Name.Text;
            Brain.vision.Save_Data();
            Close();
        }
    }
}
