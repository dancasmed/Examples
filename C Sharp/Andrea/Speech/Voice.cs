using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using Anndrea_Interfaces;
using System.Threading;

namespace Speech
{
    internal class Voice
    {
        SpeechSynthesizer synth;
        ITerminal m_Terminal;

        internal Voice(ITerminal terminal)
        {
            synth = new SpeechSynthesizer();
            m_Terminal = terminal;
        }

        internal void Start()
        {
            synth.SetOutputToDefaultAudioDevice();
            synth.Rate = -2;
            m_Terminal.Express("Voice started.",Expression_Types.Information);
        }

        internal void Speak(string str)
        {
            Thread thread = new Thread(() => this.Talk(str));
            thread.Start();
        }

        void Talk(string str)
        {
            synth.Speak(str);
        }
    }
}
