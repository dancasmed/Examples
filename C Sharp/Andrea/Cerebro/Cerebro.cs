using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cerebro
{
    public static class Cerebro
    {
        static internal Consola consola;
        static Vision vision;
        static internal bool show_vision = false;
        static public void Iniciar(Consola c)
        {
            consola = c;
            vision = new Vision();
            vision.Iniciar();
            c.println("Cerebro conectado.");
        }
     
        static public void Procesa_Texto(string str)
        {
            string[] words = str.Split(' ');
            switch(words[0])
            {
                case "show":
                    if(words.Length<2)
                    {
                        Cerebro.consola.println("Show what?");

                    }
                    else
                    {
                        switch(words[1])
                        {
                            case "vision":
                                
                                show_vision = !show_vision;
                                vision.Show_Vision(show_vision);
                                break;
                        }
                    }
                    break;
                default:
                    consola.println("?");
                    break;
            }
            

        }
    }
}
