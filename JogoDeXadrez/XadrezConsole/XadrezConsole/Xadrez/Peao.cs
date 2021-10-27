using XadrezConsole.Tabuleiro;
using XadrezConsole.Tabuleiro.Enums;

namespace XadrezConsole.Xadrez
{
    class Peao : Peca
    {
        private PartidaDeXadrez Partida;
        public Peao(Cor cores, Tabuleiros tab, PartidaDeXadrez partida) : base(cores, tab)
        {
            Partida = partida;
        }

        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = Tab.RetornaPeca(pos);
            return p != null && p.Cores != Cores;
        }

        private bool Livre(Posicao pos)
        {
            return Tab.RetornaPeca(pos) == null;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new Posicao(0, 0);

            if (Cores == Cor.Branca)
            {
                pos.DefinirValores(Posicoes.Linha - 1, Posicoes.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicoes.Linha - 2, Posicoes.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos) && QtdMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicoes.Linha - 1, Posicoes.Coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicoes.Linha - 1, Posicoes.Coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                //# Jogada Especial - Em passant
                if (Posicoes.Linha == 3)
                {
                    Posicao esquerda = new Posicao(Posicoes.Linha, Posicoes.Coluna - 1);
                    if (Tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tab.RetornaPeca(esquerda) == Partida.VulneravelEmPassant)
                    {
                        mat[esquerda.Linha - 1, esquerda.Coluna] = true;
                    }

                    Posicao direita = new Posicao(Posicoes.Linha, Posicoes.Coluna + 1);
                    if (Tab.PosicaoValida(direita) && ExisteInimigo(direita) && Tab.RetornaPeca(direita) == Partida.VulneravelEmPassant)
                    {
                        mat[direita.Linha - 1, direita.Coluna] = true;
                    }
                }
            }
            else
            {
                pos.DefinirValores(Posicoes.Linha + 1, Posicoes.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicoes.Linha + 2, Posicoes.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos) && QtdMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicoes.Linha + 1, Posicoes.Coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicoes.Linha + 1, Posicoes.Coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                //# Jogada Especial - Em passant
                if (Posicoes.Linha == 4)
                {
                    Posicao esquerda = new Posicao(Posicoes.Linha, Posicoes.Coluna - 1);
                    if (Tab.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tab.RetornaPeca(esquerda) == Partida.VulneravelEmPassant)
                    {
                        mat[esquerda.Linha + 1, esquerda.Coluna] = true;
                    }

                    Posicao direita = new Posicao(Posicoes.Linha, Posicoes.Coluna + 1);
                    if (Tab.PosicaoValida(direita) && ExisteInimigo(direita) && Tab.RetornaPeca(direita) == Partida.VulneravelEmPassant)
                    {
                        mat[direita.Linha + 1, direita.Coluna] = true;
                    }
                }
            }
            return mat;
        }
        public override string ToString()
        {
            return "P";
        }
    }
}
