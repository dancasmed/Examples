using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anndrea_Interfaces
{
    public interface ITerminal
    {
        void Get_Command(string str);
        void Express(string str, Expression_Types type);
    }
}
