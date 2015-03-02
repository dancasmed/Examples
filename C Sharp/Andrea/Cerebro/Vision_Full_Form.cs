using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;


namespace Cerebro
{
    public partial class Vision_Full_Form : Form
    {
        public Vision_Full_Form()
        {
            InitializeComponent();
        }
        public void Set_Current_Frame(Image<Bgr, Byte> frame)
        {
         
            imageBox_Current_Frame.Image = frame;
        }

        public void Set_Faces(List<Image<Gray, Byte>> faces)
        {
            imageBox_face_1.Image = null;
            imageBox_face_2.Image = null;
            imageBox_face_3.Image = null;
            imageBox_face_4.Image = null;
            if(faces.Count>0)
            {
                imageBox_face_1.Image = faces[0];

            }
            if (faces.Count > 1)
            {
                imageBox_face_2.Image = faces[1];

            }
            if (faces.Count > 2)
            {
                imageBox_face_1.Image = faces[2];

            }
            if (faces.Count > 3)
            {
                imageBox_face_1.Image = faces[3];

            }
        }

        private void Vision_Full_Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cerebro.show_vision = false;
        }

    }
}
