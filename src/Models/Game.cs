namespace n_in_row.src.Models {
    internal class Game 
    {
        public int VictoryLength { get; private set; }

        public GameBoard board { get; private set; }

        public Game(int victoryLength, GameBoard board)
        {
            VictoryLength = victoryLength;
            this.board = board;
        }

        // TODO: Francisco
        public void StartGame() { }

        // TODO: Sérgio
        public void Play() { }

        // TODO: Ricardo
        public void GameDetails() { }
  
        // TODO: Ricardo
        public void Forfeit() { }

        // TODO: Ricardo
        public void ShowGameBoard() { }
    }
}
