using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vision
{
    public partial class Vision_Person_Name_Form : Form
    {
        int index = 0;
        public Vision_Person_Name_Form(int ind)
        {
            index = ind;
            InitializeComponent();
            textBox_Name.Text = Sense.Get_Sense().m_Vision.recognized_people[index];
            imageBox_Picture.Image = Sense.Get_Sense().m_Vision.recognized_faces[index];
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            Sense.Get_Sense().m_Vision.recognized_people[index] = textBox_Name.Text;
            Sense.Get_Sense().m_Vision.Save_Data();
            Close();
        }
    }
}
