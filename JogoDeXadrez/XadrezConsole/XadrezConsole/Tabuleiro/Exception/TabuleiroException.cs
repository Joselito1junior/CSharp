using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XadrezConsole.Tabuleiro.Exception
{
    class TabuleiroException : ApplicationException
    {
        public TabuleiroException(string msg) :base(msg)
        {

        }
    }
}
