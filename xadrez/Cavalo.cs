using tabuleiro;

namespace xadrez
{
    public class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "C";
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(0, 0);

            for (int l = posicao.linha - 2; l <= posicao.linha + 2; l++)
            {
                if ((l == posicao.linha) || (l <= 0) || (l > tab.linhas)) break;

                int col = 0;

                if ((l == posicao.linha - 1) || (l == posicao.linha + 1))
                {   
                    col = posicao.coluna -2;
                    if (col > 0) pos.definirValores(l, col);
                    col = posicao.coluna + 2;
                    if (col <= tab.colunas) pos.definirValores(l, col);
                }
                else
                {
                    if ((l == posicao.linha - 2) || (l == posicao.linha + 2))
                    {                        
                        col = posicao.coluna - 1;
                        if (col > 0) pos.definirValores(l, col);
                        col = posicao.coluna + 1;
                        if (col <= tab.colunas) pos.definirValores(l, col);
                    }                                   
                }

                if ((tab.posicaoValida(pos)) && (podeMover(pos)))
                    mat[l, col] = true;
            }       

            return mat;

        }
    }
}
