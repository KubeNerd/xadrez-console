using System;
using tabuleiro;
namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }

        public Cor jogadorAtual { get; private set; }
        public bool terminada {  get; private set; }

        private HashSet<Peca> pecas;

        private HashSet<Peca> capturadas;

        public bool xeque { get; private set; }

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
            xeque = false;
        }

  
        public void executarMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQtdeMovimentos();
            Peca pecaCapturada = tab.retirarPeca(destino);
            tab.colocarPeca(p, destino);

            if (pecaCapturada != null) 
            {
                capturadas.Add(pecaCapturada);
            }
        }

        private void mudaJogador() 
        {
            if (jogadorAtual == Cor.Branca) 
            {
                jogadorAtual = Cor.Preta;
            } 
            else 
            {
                jogadorAtual = Cor.Branca;
            }
        }
        public void realizaJogada(Posicao origem, Posicao destino)
        {
            executarMovimento(origem, destino);
            turno++;
            mudaJogador();
        
        }


        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if(tab.peca(pos) == null) 
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida");
            }
            if (jogadorAtual != tab.peca(pos).cor) 
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            
            }
            if (tab.peca(pos).existeMovimentosPossiveis()) 
            {
                throw new TabuleiroException("Não há movimentos possiveis para a peça de origem escolhida.");

            }
        
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (tab.peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida.");

            }

        }

        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas) 
            {
                if (x.cor == cor) 
                {
                    aux.Add(x);
                }
                
            }

            aux.ExceptWith(pecasCapturadas(cor));

            return aux;
        }

        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }



        private void colocarPecas() 
        {
            colocarNovaPeca('a', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('b', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('c', 1, new Torre(tab, Cor.Branca));
            colocarNovaPeca('d', 1, new Torre(tab, Cor.Branca));
        }
    }
}
