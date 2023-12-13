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

        public void StartGame() { }

        public void GameDetails() { }

        public void Forfeit() { }

        public void Play() { }

        public void ShowGameBoard() { }

    }
}
