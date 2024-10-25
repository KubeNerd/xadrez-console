using tabuleiro;

namespace xadrez
{
    class Torre : Peca
    {
        //private PartidaDeXadrez partida;
        public Torre(Tabuleiro tab, Cor cor/*, PartidaDeXadrez partida*/) : base(tab, cor) 
        {
            //this.partida = partida;
        }
         
         public override string ToString() 
        {
            return "T";
        }
       
    }
}
