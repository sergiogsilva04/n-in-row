namespace n_in_row.src.Models {
    internal class Game(int victoryLength, GameBoard board, Player player1, Player player2) {
        public int VictoryLength { get; private set; } = victoryLength;
        public GameBoard Board { get; private set; } = board;
        public Player Player1 { get; private set; } = player1;
        public Player Player2 { get; private set; } = player2;

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
