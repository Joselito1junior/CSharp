using System;
using XadrezConsole.Tabuleiro;

namespace XadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Tabuleiros tab = new Tabuleiros(8, 8);
            Tela.ImprimrirTabuleiro(tab);


        }
    }
}
