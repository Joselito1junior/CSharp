using System;
using System.Collections.Generic;
using XadrezConsole.Tabuleiro;
using XadrezConsole.Tabuleiro.Enums;

namespace XadrezConsole
{
    class Tela
    {
        public static void ImprimrirTabuleiro(Tabuleiros tab) 
        {
            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.Write(8 - i + " ");
                for(int j = 0; j < tab.Colunas; j++)
                {
                    if (tab.RetornaPeca(i, j) == null)
                        Console.Write("* ");
                    else
                    {
                        ImprimirPeca(tab.RetornaPeca(i, j));
                        Console.Write(" ");
                    }                         
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        static void ImprimirPeca(Peca peca)
        {
            if (peca.Cores == Cor.Branca)
                Console.Write(peca);
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
                
        }
    }
}
