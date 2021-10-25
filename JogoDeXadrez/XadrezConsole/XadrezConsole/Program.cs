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
                PosicaoXadrez pos = new PosicaoXadrez('a', 1);
                Console.WriteLine(pos);
                Console.WriteLine(pos.ToPosicao());

            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
