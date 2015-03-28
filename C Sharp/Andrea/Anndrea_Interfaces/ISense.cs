using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anndrea_Interfaces
{
    public interface ISense
    {
        void Start(ITerminal terminal);
        void Stop();
        void Show_Sense(bool show);
        void Express(string str);
    }
}
