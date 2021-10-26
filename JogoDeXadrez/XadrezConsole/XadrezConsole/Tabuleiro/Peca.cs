using System;
using System.Collections.Generic;
using XadrezConsole.Tabuleiro.Enums;


namespace XadrezConsole.Tabuleiro
{
    class Peca
    {
        public Posicao Posicoes { get; set; }
        public Cor Cores { get; protected set; }
        public int QtdMovimentos { get; protected set; }
        public Tabuleiros Tab { get; protected set; }

        public Peca(Cor cores, Tabuleiros tab)
        {
            Posicoes = null;
            Cores = cores;
            Tab = tab;
            QtdMovimentos = 0;
        }

        public void IncrementarQtdMovimentos()
        {
            QtdMovimentos++;
        }
    }
}
