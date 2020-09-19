using System;
using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }

        public PartidaDeXadrez()
        { 
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            colocarPecas();
        }

        private void colocarPecas()
        {
            List<EPecas> pecas;
                  
            pecas = new List<EPecas> { EPecas.Peao, EPecas.Torre, EPecas.Cavalo, EPecas.Bispo, EPecas.Rainha, EPecas.Rei };
            pecas.ForEach(delegate (EPecas p)
            {
                int peao = 0;
                if (p == EPecas.Peao) peao++;
                int peca = (int)p;
                int resto = peca % 100;                
                for (int i = 1; i <= (peca/100); i++)
                {
                    int pos;
                    if (peao == 1) pos = i;
                    else
                    {
                        if (i == 1) pos = resto / 10;
                        else pos = resto % 10;                          
                    }
                    tab.colocarPeca(Factory.Criar(p, tab, Cor.Branca), new PosicaoXadrez(pos, 1 + peao).toPosicao());
                    tab.colocarPeca(Factory.Criar(p, tab, Cor.Preta), new PosicaoXadrez(pos, 8 - peao).toPosicao());
                }
            });

            Console.WriteLine();
        }

        public void validarPosicaoOrigem(Posicao pos)
        {
            if (pos.coluna > this.tab.colunas)
                throw new TabuleiroException("Esta coluna não existe.");
            if (pos.linha > this.tab.linhas)
                throw new TabuleiroException("Esta linha não existe.");
            if (tab.peca(pos) == null)
                throw new TabuleiroException("Não existe peça nesta posição.");
            if (jogadorAtual != tab.peca(pos).cor)
                throw new TabuleiroException("A peça não pertence a você.");
            if (!tab.peca(pos).existeMovimentosPossiveis())
                throw new TabuleiroException("Não há movimentos possíveis para esta peça.");
        }

        public void validarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).podeMoverPara(destino))
                throw new TabuleiroException("Posição de destino inválida!");
        }

        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQtdeMovimentos();
            Peca pCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            executaMovimento(origem, destino);
            turno++;
            mudaJogador();
        }

        private void mudaJogador()
        {
            if (jogadorAtual == Cor.Branca)
                jogadorAtual = Cor.Preta;
            else
                jogadorAtual = Cor.Branca;
        }

    }
}
