using System;
using System.Collections.Generic;
using XadrezConsole.Tabuleiro;
using XadrezConsole.Tabuleiro.Enums;

namespace XadrezConsole.Xadrez
{
    class Rei : Peca
    {
        public Rei(Cor cores, Tabuleiros tab) : base(cores, tab)
        {

        }
        public override string ToString()
        {
            return "R";
        }
    }
}
