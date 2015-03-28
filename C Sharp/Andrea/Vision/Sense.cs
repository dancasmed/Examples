using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anndrea_Interfaces;

namespace Vision
{
    public class Sense : ISense
    {
        static Sense m_Sense = null;
        public static Sense Get_Sense()
        {
            if (m_Sense == null)
                m_Sense = new Sense();
            return m_Sense;
        }

        internal Vision m_Vision = null;

        public bool Started
        {
            get
            {
                return m_Vision != null;
            }
        }
        public void Start(ITerminal terminal)
        {
            m_Vision = new Vision(terminal);
            m_Vision.Start();
        }

        public void Show_Sense(bool show)
        {
            m_Vision.Show_Vision(show);
        }

        public void Stop()
        {

        }

        public void Express(string cmd)
        {

        }
    }
}
