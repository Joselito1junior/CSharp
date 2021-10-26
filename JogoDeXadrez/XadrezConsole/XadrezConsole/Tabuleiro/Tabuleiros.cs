using System;
using System.Collections.Generic;
using XadrezConsole.Tabuleiro.Exception;


namespace XadrezConsole.Tabuleiro
{
    class Tabuleiros
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] Pecas { get; set; }

        public Tabuleiros(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }

        public Peca RetornaPeca(int linha, int coluna)
        {
            return Pecas[linha, coluna];
        }

        public Peca RetornaPeca(Posicao pos)
        {
            return Pecas[pos.Linha, pos.Coluna];
        }

        public bool ExistePeca(Posicao pos)
        {
            ValidarPosicao(pos);
            return RetornaPeca(pos) != null;
        }

        public void ColocarPeca(Peca p, Posicao pos)
        {
            if (ExistePeca(pos))
                throw new TabuleiroException("Já existe uma peça nessa posicão");
            Pecas[pos.Linha, pos.Coluna] = p;
            p.Posicoes = pos;
        }

        public Peca RetirarPecas(Posicao pos)
        {
            if (RetornaPeca(pos) == null)
                return null;

            Peca aux = RetornaPeca(pos);
            aux.Posicoes = null;
            Pecas[pos.Linha, pos.Coluna] = null;
            return aux;
        }

        public bool PosicaoValida(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas)
            {
                return false;
            }
            return true;
        }
        public void ValidarPosicao(Posicao pos)
        {
            if (!PosicaoValida(pos))
                throw new TabuleiroException("Posicao Invalida!");
        }

    }
}
