using tabuleiro;

namespace xadrez
{
    public class Torre : Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
        {

        }

        public override string ToString()
        {
            return "T";
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != this.cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(0, 0);

            for (int l = posicao.linha - 1; l <= posicao.linha + 1; l += 2)
            {
                pos.definirValores(l, posicao.coluna);
                while (tab.posicaoValida(pos) && podeMover(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                    if (tab.peca(pos) != null)
                        break;
                    if (l < posicao.linha)
                        pos.linha--;
                    else
                        pos.linha++;
                }
            }

            for (int c = posicao.coluna - 1; c <= posicao.coluna + 1; c += 2)
            {
                pos.definirValores(posicao.linha, c);
                while (tab.posicaoValida(pos) && podeMover(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                    if (tab.peca(pos) != null)
                        break;
                    if (c < posicao.coluna)
                        pos.coluna--;
                    else
                        pos.coluna++;
                }
            }

            return mat;
        }
    }
}
