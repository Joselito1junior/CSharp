using System;
using System.Collections.Generic;
using XadrezConsole.Tabuleiro;
using XadrezConsole.Tabuleiro.Enums;

namespace XadrezConsole.Xadrez
{
    class Torre : Rei
    {
        public Torre(Cor cores, Tabuleiros tab) : base(cores, tab)
        {
            
        }
        public override string ToString()
        {
            return "T";
        }
    }
}
