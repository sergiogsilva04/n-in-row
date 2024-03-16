
using n_in_row.src.Controllers;

namespace n_in_row.src.Models {
    internal class Game(Queue<Player> players, GameBoard board) {
        public Queue<Player> Players { get; private set; } = players;
        public GameBoard Board { get; private set; } = board;
        public Player CurrentPlayer { get; private set; } = players.First();
        public bool IsGameOnGoing { get; private set; } = true;

        public static Game? StartGame(PlayerController playerController, Game? currentGame) {
            Queue<Player> players = new();

            Console.WriteLine();

            for (int i = 0; i < Constants.MAX_PLAYING_PLAYERS; i++) {
                Console.Write($"Digite o nome do {i + 1}º jogador: ");
                string name = Console.ReadLine() ?? "";

                while (string.IsNullOrWhiteSpace(name)) {
                    Console.WriteLine($"\nO nome '{name}' é inválido.");

                    Console.Write($"Digite o nome do {i + 1}º jogador: ");
                    name = Console.ReadLine() ?? "";
                }

                if (!playerController.HasPlayer(name)) {
                    Console.WriteLine($"\nO jogador '{name}' não está registado.");

                    return null;
                }

                if (players.Where((player) => player.Name == name).Any()) {
                    Console.WriteLine($"\nO jogador '{name}' já foi adicionado a este jogo.");

                    return null;
                }

                Player playerToAdd = playerController.GetPlayer(name);

                if (players.Where((player) => player.Symbol == playerToAdd.Symbol).Any()) {
                    Console.WriteLine($"\nJá existe um jogador adicionado com o símbolo [{playerToAdd.Symbol}].");

                    return null;
                }

                players.Enqueue(playerController.GetPlayer(name));
            }

            Console.Write("Qual o comprimento do jogo? ");
            int columns = int.Parse(Console.ReadLine()!);

            while (string.IsNullOrWhiteSpace(columns.ToString()) || columns < Constants.MIN_BOARD_COLUMNS) {
                Console.WriteLine($"\nComprimento inválido. Tem que ter um número mínimo de {Constants.MIN_BOARD_COLUMNS} {(Constants.MIN_BOARD_COLUMNS == 1 ? "coluna" : "colunas")}.");

                Console.Write("Qual o comprimento do jogo? ");
                columns = int.Parse(Console.ReadLine()!);
            }

            Console.Write("Qual a altura do jogo? ");
            int rows = int.Parse(Console.ReadLine()!);

            while (string.IsNullOrWhiteSpace(rows.ToString()) || rows < Constants.MIN_BOARD_ROWS) {
                Console.WriteLine($"Altura inválida. Tem que ter um número mínimo de {Constants.MIN_BOARD_ROWS} {(Constants.MIN_BOARD_ROWS == 1 ? "linha" : "linhas")}.");

                Console.Write("Qual a altura do jogo? ");
                rows = int.Parse(Console.ReadLine()!);
            }

            Console.Write("Qual é o tamanho da sequência vencedora? ");
            int victoryLength = int.Parse(Console.ReadLine()!);

            while (string.IsNullOrWhiteSpace(victoryLength.ToString()) || victoryLength < Constants.MIN_VICTORY_LENGTH || victoryLength > rows || victoryLength > columns) {
                Console.WriteLine($"\nTamanho inválido. Tem que ser um número mínimo de {Constants.MIN_VICTORY_LENGTH} e não pode exceder o comprimento ({columns}) e a altura ({rows}).");

                Console.Write("\nQual é o tamanho da sequência vencedora? ");
                victoryLength = int.Parse(Console.ReadLine()!);
            }

            Console.Write("\nAdicionar alguma peça especial? [s/n]: ");
            bool addSpecialPiece = (Console.ReadLine() ?? "") == "s";

            while (addSpecialPiece) {
                string direction;

                do {
                    Console.Write("\nQual é a direção da peça? [esquerda | direita]: ");
                    direction = (Console.ReadLine() ?? "").Trim().ToLower();

                    if (direction != "esquerda" && direction != "direita") {
                        Console.WriteLine($"\nDireção inválida. As direções disponíveis são 'esquerda' e 'direita'.");

                        Console.Write("Qual é a direção da peça? ");
                        direction = (Console.ReadLine() ?? "").Trim().ToLower();
                    }

                } while (direction != "esquerda" && direction != "direita");

                SpecialPieceDirection specialPieceDirection = direction == "esquerda" ? SpecialPieceDirection.Left : SpecialPieceDirection.Right;

                Console.Write("Qual é o tamanho da peça? ");
                int specialPieceLength = int.Parse(Console.ReadLine()!);

                while (string.IsNullOrWhiteSpace(specialPieceLength.ToString()) || specialPieceLength > columns) {
                    Console.WriteLine($"\nTamanho inválido. Tem que ser um número entre 2 e o número de colunas ({columns}).");

                    Console.Write("\nQual é o tamanho da peça? ");
                    specialPieceLength = int.Parse(Console.ReadLine()!);
                }

                Console.Write("Qual é a quantidade de peças? ");
                int specialPieceQuantity = int.Parse(Console.ReadLine()!);

                while (string.IsNullOrWhiteSpace(specialPieceQuantity.ToString()) || specialPieceQuantity < 1) {
                    Console.WriteLine($"\nQuantidade inválida. Tem que haver pelo menos 1 peça.");

                    Console.Write("Qual é a quantidade de peças? ");
                    specialPieceQuantity = int.Parse(Console.ReadLine()!);
                }

                SpecialPiece specialPiece = new(specialPieceDirection, specialPieceLength, specialPieceQuantity);
                IEnumerable<SpecialPiece> existentSpecialPiece = players.First().SpecialPieces.Where((piece) => piece.Equals(specialPiece));

                if (existentSpecialPiece.Any()) {
                    existentSpecialPiece.First().AddQuantity(specialPiece.Quantity);

                } else {
                    Array.ForEach(players.ToArray(), (player) => player.AddSpecialPiece(specialPiece));
                }

                Console.WriteLine($"\nPeça especial adicionada com sucesso.");

                Console.Write("\nDeseja continuar a adicionar peças? [s/n]: ");
                addSpecialPiece = (Console.ReadLine() ?? "") == "s";
            }

            Console.WriteLine($"\nJogo iniciado com sucesso entre os jogadores:\n");

            List<Player> playerList = [..players];
            playerList = [.. playerList.OrderBy(player => player.Name)];

            Array.ForEach(playerList.ToArray(), (player) => Console.WriteLine($"{player}"));

            if (players.First().SpecialPieces.Count > 0) {
                Console.WriteLine($"\nPeças especiais disponíveis:\n");

                Array.ForEach(players.First().SpecialPieces.ToArray(), (specialPiece) => Console.WriteLine($"{specialPiece}"));

            } else {
                Console.WriteLine($"\nSem peças especiais disponíveis.");
            }

            Console.WriteLine($"\nBoa sorte, e o mais importante é... DIVIRTAM-SE!");

            return new(
                players: players,
                new GameBoard(rows: rows, columns: columns, victoryLength: victoryLength)
            );
        }

        public void Play(int column, SpecialPiece? specialPiece) {
            for (int i = 0; i < Board.Rows; i++) {
                if (Board.Grid[Board.Rows - 1, column] != null) {
                    Console.WriteLine("\nColuna completa.");

                    return;
                }

                if (Board.Grid[i, column] == null) {
                    Board.Grid[i, column] = CurrentPlayer;

                    /*                    if (specialPiece == null) {
                                            Board.Grid[i, column] = CurrentPlayer;

                                        } else {
                                            for (int j = 0; j < specialPiece.Length; j++) {
                                                Board.Grid[i, j] = CurrentPlayer;
                                            }
                                        }*/
                    ;

                    Console.WriteLine("\nPeça colocada.");

                    ShowGameBoard();

                    Player? gameStatus = CheckGameStatus();

                    if (gameStatus == null) {
                        Players.Enqueue(Players.Dequeue());
                        CurrentPlayer = Players.Peek();

                        return;
                    }

                    IsGameOnGoing = false;

                    if (gameStatus.Name == "draw") {
                        Players.ToList().ForEach((player) => player.SetStatistics(StatisticType.Draw));

                        Console.Write("\nJogo empatado!");

                        return;
                    }

                    CurrentPlayer.SetStatistics(StatisticType.Victory);

                    Players.Where((player) => player.Name != CurrentPlayer.Name).ToList().ForEach((player) => player.SetStatistics(StatisticType.Defeat));

                    Console.WriteLine($"\nJogo terminado, venceu: {gameStatus}.");

                    return;
                }
            }
        }

        private Player? CheckGameStatus() {
            int victoryLength = Board.VictoryLength;

            for (var row = victoryLength - 1; row < Board.Rows; row++) {
                for (var column = 0; column < Board.Columns; column++) {
                    if (Board.Grid[row, column] != null) {
                        // Vertical
                        if (row - victoryLength + 1 >= 0) {
                            bool isVictory = true;

                            for (var i = 1; i < victoryLength; i++) {
                                if (Board.Grid[row, column] != Board.Grid[row - i, column]) {
                                    isVictory = false;

                                    break;
                                }
                            }

                            if (isVictory) {
                                return Board.Grid[row, column];
                            }
                        }

                        // Horizontal
                        if (column + victoryLength <= Board.Columns) {
                            bool isVictory = true;

                            for (var i = 1; i < victoryLength; i++) {
                                if (Board.Grid[row, column] != Board.Grid[row, column + i]) {
                                    isVictory = false;

                                    break;
                                }
                            }

                            if (isVictory) {
                                return Board.Grid[row, column];
                            }
                        }

                        // Diagonal (direita)
                        if (row - victoryLength + 1 >= 0 && column + victoryLength <= Board.Columns) {
                            bool isVictory = true;

                            for (var i = 1; i < victoryLength; i++) {
                                if (Board.Grid[row, column] != Board.Grid[row - i, column + i]) {
                                    isVictory = false;

                                    break;
                                }
                            }

                            if (isVictory) {
                                return Board.Grid[row, column];
                            }
                        }

                        // Diagonal (esquerda)
                        if (row - victoryLength + 1 >= 0 && column - victoryLength + 1 >= 0) {
                            bool isVictory = true;

                            for (var i = 1; i < victoryLength; i++) {
                                if (Board.Grid[row, column] != Board.Grid[row - i, column - i]) {
                                    isVictory = false;

                                    break;
                                }
                            }

                            if (isVictory) {
                                return Board.Grid[row, column];
                            }
                        }
                    }
                }
            }

            for (var row = 0; row < Board.Rows; row++) {
                for (var column = 0; column < Board.Columns; column++) {
                    if (Board.Grid[row, column] == null) {
                        return null;
                    }
                }
            }

            return new Player("draw", "");
        }


        // TODO: Ricardo
        public void GameDetails() { }

        // TODO: Ricardo
        public void Forfeit(Game? currentGame) 
        {
            if (currentGame == null) {
                Console.WriteLine("Nao existe jogo em curso");
                return;
            }

            // Get the other player
            Player otherPlayer = currentGame.Players.First(player => player != currentGame.CurrentPlayer);

            // Register a defeat for the player who forfeited
            currentGame.CurrentPlayer.SetStatistics(StatisticType.Defeat);

            // Register a victory for the other player
            otherPlayer.SetStatistics(StatisticType.Victory);

            // End the game
            currentGame.IsGameOnGoing = false;

            Console.WriteLine("\nDesistencia com sucesso. Jogo terminado");
        }


        // TODO: Sérgio
        private void ShowGameBoard() {
            Console.WriteLine();

            for (int i = Board.Rows; i > 0; i--) {
                for (int j = 0; j < Board.Columns; j++) {
                    Console.Write(Board.Grid[i - 1, j]?.Symbol ?? "-");
                }

                Console.WriteLine();
            }
        }

        public bool HasPlayer(string playerName) {
            return Players.Where((player) => player.Name == playerName.Trim().ToLower()).Any();
        }
    }
}