using System;
using XadrezConsole.Tabuleiro;
using XadrezConsole.Xadrez;
using XadrezConsole.Tabuleiro.Enums;
using XadrezConsole.Tabuleiro.Exception;

namespace XadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Tabuleiros tab = new Tabuleiros(8, 8);

                tab.ColocarPeca(new Torre(Cor.Preta, tab), new Posicao(0, 0));
                tab.ColocarPeca(new Torre(Cor.Preta, tab), new Posicao(1, 3));
                tab.ColocarPeca(new Rei(Cor.Preta, tab), new Posicao(2, 4));

                tab.ColocarPeca(new Rei(Cor.Branca, tab), new Posicao(3, 5));
                Tela.ImprimrirTabuleiro(tab);
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
