
namespace tabuleiro
{
    //Se a classe possui pelo menos 1 método abastrato, então ela precisa ser abstrata.
    abstract class Peca
    {

        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public Tabuleiro tab { get; protected set; }
        public int qteMovimento { get; set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            this.posicao = null;
            this.cor = cor;
            this.tab = tab;
            this.qteMovimento = 0;

        }

        public abstract bool[,] movimentosPossiveis();

        public void incrementarQtdeMovimentos()
        {
            qteMovimento++;
        }

        public bool podeMoverPara(Posicao pos) 
        {

            return movimentosPossiveis()[pos.linha, pos.coluna];
        
        }



        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentosPossiveis();
            for (int i = 0; i < tab.linhas; i++)
            {
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void decrementarQtdeMovimentos()
        {
            qteMovimento--;
        }
    


    }
}
