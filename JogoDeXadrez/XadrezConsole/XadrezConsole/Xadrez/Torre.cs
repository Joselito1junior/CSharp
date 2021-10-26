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
        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.RetornaPeca(pos);
            return p == null || p.Cores != Cores;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new Posicao(0, 0);

            //Acima
            pos.DefinirValores(Posicoes.Linha - 1, Posicoes.Coluna);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.RetornaPeca(pos) != null && Tab.RetornaPeca(pos).Cores != Cores)
                {
                    break;
                }
                pos.Linha = pos.Linha - 1;
            }

            //Abaixo
            pos.DefinirValores(Posicoes.Linha + 1, Posicoes.Coluna);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.RetornaPeca(pos) != null && Tab.RetornaPeca(pos).Cores != Cores)
                {
                    break;
                }
                pos.Linha = pos.Linha + 1;
            }

            //Direita
            pos.DefinirValores(Posicoes.Linha, Posicoes.Coluna + 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.RetornaPeca(pos) != null && Tab.RetornaPeca(pos).Cores != Cores)
                {
                    break;
                }
                pos.Coluna = pos.Coluna + 1;
            }

            //Esquerda
            pos.DefinirValores(Posicoes.Linha, Posicoes.Coluna - 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.RetornaPeca(pos) != null && Tab.RetornaPeca(pos).Cores != Cores)
                {
                    break;
                }
                pos.Coluna = pos.Coluna - 1;
            }

            return mat;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
