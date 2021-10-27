using System;
using System.Collections.Generic;
using XadrezConsole.Tabuleiro;
using XadrezConsole.Tabuleiro.Enums;

namespace XadrezConsole.Xadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrez Partida;
        public Rei(Cor cores, Tabuleiros tab, PartidaDeXadrez partida) : base(cores, tab)
        {
            Partida = partida;
        }
        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.RetornaPeca(pos);
            return p == null || p.Cores != Cores;
        }

        private bool TesteTorreParaRoque(Posicao pos)
        {
            Peca p = Tab.RetornaPeca(pos);
            return p != null && p is Torre && p.Cores == Cores && p.QtdMovimentos == 0;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new Posicao(0, 0);

            pos.DefinirValores(Posicoes.Linha - 1, Posicoes.Coluna);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            pos.DefinirValores(Posicoes.Linha - 1, Posicoes.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            pos.DefinirValores(Posicoes.Linha, Posicoes.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            pos.DefinirValores(Posicoes.Linha + 1, Posicoes.Coluna + 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            pos.DefinirValores(Posicoes.Linha + 1, Posicoes.Coluna);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            pos.DefinirValores(Posicoes.Linha + 1, Posicoes.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            pos.DefinirValores(Posicoes.Linha, Posicoes.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;


            pos.DefinirValores(Posicoes.Linha - 1, Posicoes.Coluna - 1);
            if (Tab.PosicaoValida(pos) && PodeMover(pos))
                mat[pos.Linha, pos.Coluna] = true;

            //# Jogada especial - Roque

            if (QtdMovimentos == 0 && !Partida.Xeque)
            { //#Jogada especial - Roque Pequeno
                Posicao posT1 = new Posicao(Posicoes.Linha, Posicoes.Coluna + 3);
                if (TesteTorreParaRoque(posT1))
                {
                    Posicao p1 = new Posicao(Posicoes.Linha, Posicoes.Coluna + 1);
                    Posicao p2 = new Posicao(Posicoes.Linha, Posicoes.Coluna + 2);

                    if (Tab.RetornaPeca(p1) == null && Tab.RetornaPeca(p2) == null)
                    {
                        mat[Posicoes.Linha, Posicoes.Coluna + 2] = true;
                    }
                }
                //#Jogada especial - Roque Grande
                Posicao posT2 = new Posicao(Posicoes.Linha, Posicoes.Coluna - 4);
                if (TesteTorreParaRoque(posT2))
                {
                    Posicao p1 = new Posicao(Posicoes.Linha, Posicoes.Coluna - 1);
                    Posicao p2 = new Posicao(Posicoes.Linha, Posicoes.Coluna - 2);
                    Posicao p3 = new Posicao(Posicoes.Linha, Posicoes.Coluna - 3);

                    if (Tab.RetornaPeca(p1) == null && Tab.RetornaPeca(p2) == null && Tab.RetornaPeca(p3) == null)
                    {
                        mat[Posicoes.Linha, Posicoes.Coluna - 2] = true;
                    }
                }
            }
            return mat;
        }
        public override string ToString()
        {
            return "R";
        }
    }
}
