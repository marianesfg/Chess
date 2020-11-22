using tabuleiro;

namespace xadrez
{
    public class Bispo : Peca
    {
        public Bispo(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }     

        public override string ToString()
        {
            return "B";
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(0, 0);
            int col, row = 0;

            for (int l = posicao.linha - 1; l > 0; l--)
            {
                row++;
                col = posicao.coluna - row;
                if (col > 0) pos.definirValores(l, col);
                col = posicao.coluna + row;
                if (col <= tab.colunas) pos.definirValores(l, col);

                pos.definirValores(l, col);
                if (tab.posicaoValida(pos) && podeMover(pos))
                    mat[pos.linha, pos.coluna] = true;
            }

            for (int l = posicao.linha + 1; l <= tab.linhas; l++)
            {
                row++;
                col = posicao.coluna - row;
                if (col > 0) pos.definirValores(l, col);
                col = posicao.coluna + row;
                if (col <= tab.colunas) pos.definirValores(l, col);

                pos.definirValores(l, col);
                if (tab.posicaoValida(pos) && podeMover(pos))
                    mat[pos.linha, pos.coluna] = true;
            }

            return mat;
        }
    }
}
