using System;
using tabuleiro;

namespace xadrez
{
    public static class Factory
    {
        public static Peca Criar(EPecas peca, Tabuleiro tab, Cor cor)
        {
            return Criar(peca.ToString(), tab, cor);
        }
       
        public static Peca Criar(String peca, Tabuleiro tab, Cor cor)
        {
            switch (peca)
            {
                default:
                case "Bispo":
                    return new Bispo(tab, cor);
                case "Cavalo":
                    return new Cavalo(tab, cor);
                case "Peao":
                    return new Peao(tab, cor);
                case "Rainha":
                    return new Rainha(tab, cor);
                case "Rei":
                    return new Rei(tab, cor);
                case "Torre":
                    return new Torre(tab, cor);
            }
        }
    }
}

