namespace tabuleiro
{
    public abstract class Peca
    {
        protected string Nome { get; set; }
        public Posicao posicao { get; set; }

        public Cor cor { get; protected set; }

        public int qtdeMovimentos { get; set; }

        public Tabuleiro tab { get; protected set; }

        public Peca (Tabuleiro tab, Cor cor)
        {
            this.posicao = null;
            this.tab = tab;
            this.cor = cor;
            this.qtdeMovimentos = 0;
        }
        
        public bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != this.cor;
        }

        public void incrementarQtdeMovimentos()
        {
            qtdeMovimentos++;
        }

        public void decrementarQtdeMovimentos()
        {
            qtdeMovimentos--;
        }

        public abstract bool[,] movimentosPossiveis();

        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentosPossiveis();
            for (int i = 0; i < tab.linhas; i++)
            {
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (mat[i, j])
                        return true;
                }
            }
            return false;
        }

        public bool podeMoverPara(Posicao pos)
        {
            return movimentosPossiveis()[pos.linha, pos.coluna];
        }
    }
}
