namespace n_in_row.src.Models {
    internal class Game(int victoryLength, GameBoard board, Player player1, Player player2) {
        public int VictoryLength { get; private set; } = victoryLength;
        public GameBoard Board { get; private set; } = board;
        public Player Player1 { get; private set; } = player1;
        public Player Player2 { get; private set; } = player2;

        // TODO: Francisco
        public void StartGame() {
            
         
            if (Board.IsGameStarted)
            {
                Console.WriteLine("Game is already started. Cannot start a new game.");
                return;
            }

            string playerName1 = Player1.Name;
            string playerName2 = Player2.Name;

            string[] sortedPlayerNames = { playerName1, playerName2 };
            Array.Sort(sortedPlayerNames);

            Console.WriteLine("Players in alphabetical order:");
            foreach (var playerName in sortedPlayerNames)
            {
                Console.WriteLine(playerName);
            }

        
            Board.IsGameStarted = true;
        }

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
