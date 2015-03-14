using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sin_duplicados
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_buscar_sin_duplicados_Click(object sender, EventArgs e)
        {
            string[] palabras_originales = textBox_Lista_Original.Text.Split('\n');
            bool duplicado_detectado = false;
            foreach(string palabra in palabras_originales)
            {
                duplicado_detectado=false;
                for(int i=0; i<palabra.Length; i++)
                {
                    for(int j= i+1; j<palabra.Length;j++)
                    {
                        if(palabra[i]==palabra[j])
                        {
                            duplicado_detectado = true;
                            break;
                        }
                    }
                    if(duplicado_detectado==true)
                    {
                        break;
                    }
                }
                if(duplicado_detectado == false)
                {
                    textBox_Lista_Resultados.Text += palabra + Environment.NewLine;
                }
            }
        }
    }
}
