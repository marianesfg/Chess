using System;

using tabuleiro;
using xadrez;
using xadrez_console.xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Posicao p = new Posicao(3, 4);
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
                tab.colocarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 3));
                tab.colocarPeca(new Rei(tab, Cor.Preta), new Posicao(4, 4));
                tab.colocarPeca(new Torre(tab, Cor.Branca), new Posicao(3, 5));

                Tela.imprimirTabuleiro(tab);

                Console.ReadLine();

                //PosicaoXadrez posicaoXadrez = new PosicaoXadrez('a', 1);
                //Console.WriteLine(posicaoXadrez);
                //Console.WriteLine(posicaoXadrez.toPosicao());
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
