
namespace n_in_row.src.Models {
    internal class Game(int victoryLength, GameBoard board, Player player1, Player player2) {
        public int VictoryLength { get; private set; } = victoryLength;
        public GameBoard Board { get; private set; } = board;
        public Player Player1 { get; private set; } = player1;
        public Player Player2 { get; private set; } = player2;
        public Player CurrentPlayer { get; private set; } = player1;
        public bool IsGameFinished { get; private set; } = false;

        // TODO: Francisco
        public void StartGame() { }

        // TODO: Sérgio
        public void Play(int column, SpecialPiece? specialPiece) {
            for (int i = 0; i < Board.Lines; i++) {
                if (Board.Grid[Board.Lines - 1, column] != null) {
                    Console.WriteLine("Coluna completa.");

                    return;
                }

                if (specialPiece != null) {
                    for (int j = 0; j < specialPiece.Length; j++) {
                        Board.Grid[i, j] = CurrentPlayer;
                    }

                    Console.WriteLine("Peça colocada.");

                    ShowGameBoard();

                    return;
                }


                if (Board.Grid[i, column] == null) {
                    Board.Grid[i, column] = CurrentPlayer;

                    CurrentPlayer = CurrentPlayer == Player1 ? Player2 : Player1;

                    Console.WriteLine("Peça colocada.");

                    ShowGameBoard();

                    Player? gameStatus = CheckGameStatus();

                    if (gameStatus == null) {
                        return;
                    }

                    IsGameFinished = true;

                    if (gameStatus.Name == "draw") {
                        Console.Write("\nJogo empatado!");

                        return;
                    }

                    Console.Write($"\nJogo terminado, venceu: {gameStatus.Name}");


                    return;
                }
            }
        }

        private Player? CheckGameStatus() {
            for (var row = 3; row < Board.Lines; row++) {
                for (var column = 0; column < Board.Columns; column++) {
                    if (Board.Grid[row, column] != null) {
                        if (Board.Grid[row, column] == Board.Grid[row - 1, column] &&
                            Board.Grid[row, column] == Board.Grid[row - 2, column] &&
                            Board.Grid[row, column] == Board.Grid[row - 3, column]) {
                            return Board.Grid[row, column];
                        }
                    }
                }
            }

            for (var row = 0; row < Board.Lines; row++) {
                for (var column = 0; column < Board.Columns - 3; column++) {
                    if (Board.Grid[row, column] != null) {
                        if (Board.Grid[row, column] == Board.Grid[row, column + 1] &&
                            Board.Grid[row, column] == Board.Grid[row, column + 2] &&
                            Board.Grid[row, column] == Board.Grid[row, column + 3]) {
                            return Board.Grid[row, column];
                        }
                    }
                }
            }

            for (var row = 3; row < Board.Lines - 3; row++) {
                for (var column = 0; column < Board.Columns - 3; column++) {
                    if (Board.Grid[row, column] != null) {
                        if (Board.Grid[row, column] == Board.Grid[row - 1, column + 1] &&
                            Board.Grid[row, column] == Board.Grid[row - 2, column + 2] &&
                            Board.Grid[row, column] == Board.Grid[row - 3, column + 3]) {
                            return Board.Grid[row, column];
                        }
                    }
                }
            }

            for (var row = 3; row < Board.Lines; row++) {
                for (var column = 3; column < Board.Columns; column++) {
                    if (Board.Grid[row, column] != null) {
                        if (Board.Grid[row, column] == Board.Grid[row - 1, column - 1] &&
                            Board.Grid[row, column] == Board.Grid[row - 2, column - 1] &&
                            Board.Grid[row, column] == Board.Grid[row - 3, column - 1]) {
                            return Board.Grid[row, column];
                        }
                    }
                }
            }

            for (var row = 0; row < Board.Lines; row++) {
                for (var column = 0; column < Board.Columns; column++) {
                    if (Board.Grid[row, column] == null) {
                        return null;
                    }
                }
            }

            return new Player("draw", "", "");
        }

        // TODO: Ricardo
        public void GameDetails() { }

        // TODO: Ricardo
        public void Forfeit() { }

        // TODO: Sérgio
        public void CreateSpecialPiece() {

        }

        // TODO: Sérgio
        private void ShowGameBoard() {
            Console.WriteLine();

            for (int i = Board.Lines; i > 0; i--) {
                for (int j = 0; j < Board.Columns; j++) {
                    Console.Write(Board.Grid[i - 1, j]?.Symbol ?? "-");
                }

                Console.WriteLine();
            }
        }
    }
}