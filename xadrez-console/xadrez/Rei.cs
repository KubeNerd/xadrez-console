using tabuleiro;


namespace xadrez
{
    class Rei : Peca
    {
        //private PartidaDeXadrez partida;
        public Rei(Tabuleiro tab, Cor cor/*, PartidaDeXadrez partida*/) : base(tab, cor) 
        {
          //this.partida = partida;
        
        }
         
         public override string ToString() 
        {
            return "R";
        }
       
    }
}
