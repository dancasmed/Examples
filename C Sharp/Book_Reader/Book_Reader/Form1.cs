using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Speech.Synthesis;

namespace Book_Reader
{
    //This example apen a book in TXT format and reads the first 100 lines using the
    //voice synthesys of System.Speech library (check references of the project)


    public partial class Form1 : Form
    {
        List<string> book_lines;
        public Form1()
        {
            InitializeComponent();
            book_lines = new List<string>();
        }

        private void button_Open_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            StreamReader sr = new StreamReader(openFileDialog1.FileName);
            string buff = sr.ReadToEnd();
            buff = buff.Replace('\r',' ');
            string [] raw_lines = buff.Split('\n');
            book_lines.Clear();
            textBox2.Text = "";
            for(int i=0; i<raw_lines.Length;i++)
            {
                string line = raw_lines[i].Trim(); //removes the spaces at start and end of the line
                if(line.Length>0)
                {
                    book_lines.Add(line);
                    
                }
            }
            textBox2.Text = buff;
        }

        private void button_Read_Click(object sender, EventArgs e)
        {
            SpeechSynthesizer voice = new SpeechSynthesizer();
            for(int i=0; i<100; i++)
            {
                voice.Speak(book_lines[i]);
            }

        }
    }
}
