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
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while(!partida.Terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.ImprimrirTabuleiro(partida.tab);
                        Console.WriteLine();
                        Console.WriteLine("Turno: " + partida.Turno);
                        Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);


                        Console.Write("Origem: ");
                        Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoOrigem(origem);

                        bool[,] posicoesPossiveis = partida.tab.RetornaPeca(origem).MovimentosPossiveis();


                        Console.Clear();
                        Tela.ImprimrirTabuleiro(partida.tab, posicoesPossiveis);
                        //Tela.ImprimrirTabuleiro(partida.tab);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoDestino(origem, destino);

                        partida.ExecutaMovimento(origem, destino);
                    }
                    catch(TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
