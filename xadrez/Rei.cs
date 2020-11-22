using tabuleiro;
using xadrez_console.teste;

namespace xadrez
{
    public class Rei : Peca
    {
        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "R";
        }
     
        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(0, 0);
            
            for (int l = posicao.linha - 1; l <= posicao.linha + 1; l++)
            {
                for (int c = posicao.coluna - 1; c <= posicao.coluna + 1; c++)
                {
                    if ((l != posicao.linha) || (c != posicao.coluna))
                    {
                        pos.definirValores(l, c);
                        if (tab.posicaoValida(pos) && podeMover(pos))
                            mat[pos.linha, pos.coluna] = true;
                    }                    
                }
            }
            return mat;
        }
    }
}
