﻿using System;
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

        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;

        public PartidaDeXadrez()
        { 
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }

        private void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }

        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca peca in capturadas)
            {
                if (cor == peca.cor)
                    aux.Add(peca);
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca peca in pecas)
            {
                if (cor == peca.cor)
                    aux.Add(peca);
            }

            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        private void colocarPecas()
        {
            char col;
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
                    col = Convert.ToChar(96 + pos);
                    colocarNovaPeca(col, 1 + peao, Factory.Criar(p, tab, Cor.Branca));
                    colocarNovaPeca(col, 8 - peao, Factory.Criar(p, tab, Cor.Preta));          
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
            if (pCapturada != null)
                capturadas.Add(pCapturada);
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
