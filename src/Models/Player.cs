namespace n_in_row.src.Models {
   
    internal class Player {
    
        public string Name { get; private set; }
        private int Symbol { get; private set; }
        private int Color { get; private set; }
        private int Victories { get; private set; }
        private int Draws { get; private set; }
        private int Loses { get; private set; }

        public Player(string name, string symbol, string color)
        {
           Name = name;
           Symbol = symbol;
           Color = color;
           Victories = 0;
           Draws = 0;
           Loses = 0;
        }
        
        public int TotalGamesPlayed()
        {
            return Victories + Draws + Loses;
        }
                
    }
}
