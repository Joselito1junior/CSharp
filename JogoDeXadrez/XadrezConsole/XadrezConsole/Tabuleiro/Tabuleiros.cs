using System;
using System.Collections.Generic;


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

        public Peca retornaPeca(int linha, int coluna)
        {
            return Pecas[linha, coluna];
        }
    }
}
