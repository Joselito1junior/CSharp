using System;
using XadrezConsole.Tabuleiro;
using XadrezConsole.Tabuleiro.Enums;
using XadrezConsole.Tabuleiro.Exception;
using System.Collections.Generic;

namespace XadrezConsole.Xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiros tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capturadas;

        public PartidaDeXadrez()
        {
            tab = new Tabuleiros(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.RetirarPecas(origem);
            p.IncrementarQtdMovimentos();
            Peca pecaCapturada = tab.RetirarPecas(destino);
            tab.ColocarPeca(p, destino);
            if(pecaCapturada != null)
            {
                Capturadas.Add(pecaCapturada);
            }
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador();
        }

        public void ValidarPosicaoOrigem(Posicao pos)
        {
            if (tab.RetornaPeca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida");
            }
            if (JogadorAtual != tab.RetornaPeca(pos).Cores)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua");
            }
            if (!tab.RetornaPeca(pos).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis");
            }
        }


        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!tab.RetornaPeca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posicão de destino Invalida");
            }
        }

        private void MudaJogador()
        {
            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            Pecas.Add(peca);
        }

        public HashSet<Peca> PecasCapturdas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in Capturadas)
            {
                if(x.Cores == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in Pecas)
            {
                if(x.Cores == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(PecasCapturdas(cor));
            return aux;
        }

        private void ColocarPecas()
        {
            ColocarNovaPeca('c', 1, new Torre(Cor.Branca, tab));
            ColocarNovaPeca('c', 2, new Torre(Cor.Branca, tab));
            ColocarNovaPeca('d', 2, new Torre(Cor.Branca, tab));
            ColocarNovaPeca('e', 2, new Torre(Cor.Branca, tab));
            ColocarNovaPeca('e', 1, new Torre(Cor.Branca, tab));
            ColocarNovaPeca('d', 1, new Rei(Cor.Branca, tab));

            ColocarNovaPeca('c', 7, new Torre(Cor.Preta, tab));
            ColocarNovaPeca('c', 8, new Torre(Cor.Preta, tab));
            ColocarNovaPeca('d', 7, new Torre(Cor.Preta, tab));
            ColocarNovaPeca('e', 7, new Torre(Cor.Preta, tab));
            ColocarNovaPeca('e', 8, new Torre(Cor.Preta, tab));
            ColocarNovaPeca('d', 8, new Rei(Cor.Preta, tab));
        }
    }
}
