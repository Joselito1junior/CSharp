using System;
using System.Collections.Generic;
using XadrezConsole.Tabuleiro.Enums;


namespace XadrezConsole.Tabuleiro
{
    abstract class Peca
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

        public bool ExisteMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();

            for (int i = 0; i < Tab.Linhas; i++)
            {
                for (int j = 0; j < Tab.Colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool PodeMoverPara(Posicao pos)
        {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }

        public abstract bool[,] MovimentosPossiveis();
    }
}
