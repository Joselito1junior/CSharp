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
  
        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.RetornaPeca(pos);
            return p == null || p.Cores != Cores;
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

            return mat;
        }
        public override string ToString()
        {
            return "R";
        }
    }
}
