namespace n_in_row.src.Models {
   
    internal class Player {
    
        public string Name { get; private set; }
        private int _victories;
        private int _symbol;
        private int _color;
        private int _totalGamesPlayed; 
        private int _draws;
        private int _loses;

 

        public int Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public int Symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }

        public int Victories
        {
            get { return _victories; }
            set { _victories = value; }
        }

        public int TotalGamesPlayed
        {
            get { return _totalGamesPlayed; }
            set { _totalGamesPlayed = value; }
        }

        public int Draws
        {
            get { return _draws; }
            set { _draws = value; }
        }

        public int Loses
        {
            get { return _loses; }
            set { _loses = value; }
        }

        
        public Player(string name)
        {
            _name = name;
            _victories = 0;
            _totalGamesPlayed = 0; 
            _draws = 0;
            _loses = 0;
        }
    }
}
