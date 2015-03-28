using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anndrea_Interfaces;

namespace Speech
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

        internal Voice m_Voice = null;

        public bool Started
        {
            get
            {
                return m_Voice != null;
            }
        }
        public void Start(ITerminal terminal)
        {
            m_Voice = new Voice(terminal);
            m_Voice.Start();
        }

        public void Show_Sense(bool show)
        {
            
        }

        public void Stop()
        {

        }
        public void Express(String cmd)
        {
            m_Voice.Speak(cmd);
        }
    }
}
