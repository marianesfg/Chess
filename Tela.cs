using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Tela
    {
        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            imprimirTabuleiro(partida.tab);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno);
            Console.WriteLine("Aguardando jogada " + partida.jogadorAtual);
        }

        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach(Peca x in conjunto) Console.Write(x + " ");           
            Console.Write("]");
        }

        public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças capturadas");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.Write(" Pretas: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.ResetColor();
        }

        public static void imprimirTabuleiro (Tabuleiro tab)
        {
            for (int i=0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + "");
                for (int j=0; j<tab.colunas; j++)
                {
                    if (tab.peca(i, j) == null)
                        Console.Write(" -");
                    else                    
                        imprimirPeca(tab.peca(i, j));                       
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray; 

            for (int i = 0; i < tab.linhas; i++)
            {
                Console.BackgroundColor = fundoOriginal;
                Console.Write(8 - i + "");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                        Console.BackgroundColor = fundoAlterado;
                    else
                        Console.BackgroundColor = fundoOriginal;

                    if (tab.peca(i, j) == null)
                        Console.Write(" -");
                    else
                    {
                        //Console.Write(" ");
                        imprimirPeca(tab.peca(i, j));
                    }
                }
                Console.WriteLine();
            }            
            Console.WriteLine("  a b c d e f g h");
        }

        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1].ToString());
            return new PosicaoXadrez(coluna, linha);
        }

        public static void imprimirPeca(Peca peca)
        {
            if (peca == null)
                Console.WriteLine(" -");
            else
            {
                Console.Write(" ");
                if (peca.cor == Cor.Preta)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ResetColor();
                }
                else
                    Console.Write(peca);
                
            }
        }
    }
}
