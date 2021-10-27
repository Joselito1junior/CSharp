using XadrezConsole.Tabuleiro;
using XadrezConsole.Tabuleiro.Enums;


namespace XadrezConsole.Xadrez
{
    class Dama : Peca
    {
        public Dama(Cor cores, Tabuleiros tab) : base(cores, tab)
        {
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

            //Noroeste
            pos.DefinirValores(Posicoes.Linha - 1, Posicoes.Coluna - 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.RetornaPeca(pos) != null && Tab.RetornaPeca(pos).Cores != Cores)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
            }

            //Nordeste
            pos.DefinirValores(Posicoes.Linha - 1, Posicoes.Coluna + 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.RetornaPeca(pos) != null && Tab.RetornaPeca(pos).Cores != Cores)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha - 1, pos.Coluna + 1);
            }

            //Sudeste
            pos.DefinirValores(Posicoes.Linha + 1, Posicoes.Coluna + 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.RetornaPeca(pos) != null && Tab.RetornaPeca(pos).Cores != Cores)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha + 1, pos.Coluna + 1);
            }

            //Suldoeste
            pos.DefinirValores(Posicoes.Linha + 1, Posicoes.Coluna - 1);
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.RetornaPeca(pos) != null && Tab.RetornaPeca(pos).Cores != Cores)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha + 1, pos.Coluna - 1);
            }

            return mat;
        }
        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.RetornaPeca(pos);
            return p == null || p.Cores != Cores;
        }

        public override string ToString()
        {
            return "D";
        }
    }
}
