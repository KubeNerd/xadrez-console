﻿using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
 

                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada) 
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.tab);

                    Console.WriteLine();
                    Console.Write("Origem:");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();

                    Console.Write("Destino:");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();


                    partida.executarMovimento(origem, destino);
                }

            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);    
            
            }

        }
    }
}