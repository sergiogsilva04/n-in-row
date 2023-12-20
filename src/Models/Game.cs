namespace n_in_row.src.Models {
    internal class Game 
    {
        public int VictoryLength { get; private set; }
        public GameBoard Board { get; private set; }
        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }

        public Game(int victoryLength, GameBoard board, Player player1, Player player2)
        {
            VictoryLength = victoryLength;
            Board = board;
            Player1 = player1;
            Player2 = player2;
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
