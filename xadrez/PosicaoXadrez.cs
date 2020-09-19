﻿using System;
using tabuleiro;

namespace xadrez
{
    class PosicaoXadrez
    {
        public char coluna { get; set; }

        public int linha { get; set; }

        public PosicaoXadrez(int coluna, int linha)
        {

            this.coluna = Convert.ToChar(96 + coluna);
            this.linha = linha;
        }

        public PosicaoXadrez(char coluna, int linha)
        {
            this.coluna = coluna;
            this.linha = linha;
        }

        public Posicao toPosicao()
        {
            return new Posicao(8 - this.linha, this.coluna - 'a');            
        }

        public override string ToString()
        {
            return "" + coluna + linha;
        }
    }
}
