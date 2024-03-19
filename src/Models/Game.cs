using n_in_row.src.Controllers;
using n_in_row.src.Models;
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
                    Console.WriteLine($"O nome '{name}' é inválido.");

                    Console.Write($"\nDigite o nome do {i + 1}º jogador: ");
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
            bool isValidInput = int.TryParse(Console.ReadLine(), out int columns);

            while (!isValidInput || string.IsNullOrWhiteSpace(columns.ToString()) || columns < Constants.MIN_BOARD_COLUMNS) {
                Console.WriteLine($"Comprimento inválido. Tem que ter um número mínimo de {Constants.MIN_BOARD_COLUMNS} {(Constants.MIN_BOARD_COLUMNS == 1 ? "coluna" : "colunas")}.");

                Console.Write("\nQual o comprimento do jogo? ");
                isValidInput = int.TryParse(Console.ReadLine(), out columns);
            }

            Console.Write("Qual a altura do jogo? ");
            isValidInput = int.TryParse(Console.ReadLine(), out int rows);

            while (!isValidInput || string.IsNullOrWhiteSpace(rows.ToString()) || rows < Constants.MIN_BOARD_ROWS) {
                Console.WriteLine($"Altura inválida. Tem que ter um número mínimo de {Constants.MIN_BOARD_ROWS} {(Constants.MIN_BOARD_ROWS == 1 ? "linha" : "linhas")}.");

                Console.Write("\nQual a altura do jogo? ");
                isValidInput = int.TryParse(Console.ReadLine(), out rows);
            }

            Console.Write("Qual é o tamanho da sequência vencedora? ");
            isValidInput = int.TryParse(Console.ReadLine(), out int victoryLength);

            while (!isValidInput || string.IsNullOrWhiteSpace(victoryLength.ToString()) || victoryLength < Constants.MIN_VICTORY_LENGTH
                || victoryLength > rows || victoryLength > columns) {

                Console.WriteLine($"Tamanho inválido. Tem que ser um número mínimo de {Constants.MIN_VICTORY_LENGTH} e não pode exceder o comprimento ({columns}) e a altura ({rows}).");

                Console.Write("\nQual é o tamanho da sequência vencedora? ");
                isValidInput = int.TryParse(Console.ReadLine(), out victoryLength);
            }

            Console.Write("\nAdicionar alguma peça especial? [s/n]: ");
            bool addSpecialPiece = (Console.ReadLine() ?? "") == "s";

            while (addSpecialPiece) {
                string direction;

                do {
                    Console.Write("\nQual é a direção da peça? [esquerda | direita]: ");
                    direction = (Console.ReadLine() ?? "").Trim().ToLower();

                    if (direction != "esquerda" && direction != "direita") {
                        Console.WriteLine($"Direção inválida. As direções disponíveis são 'esquerda' e 'direita'.");

                        Console.Write("\nQual é a direção da peça? ");
                        direction = (Console.ReadLine() ?? "").Trim().ToLower();
                    }

                } while (direction != "esquerda" && direction != "direita");

                SpecialPieceDirection specialPieceDirection = direction == "esquerda" ? SpecialPieceDirection.Left : SpecialPieceDirection.Right;

                Console.Write("Qual é o tamanho da peça? ");
                isValidInput = int.TryParse(Console.ReadLine(), out int specialPieceLength);

                while (!isValidInput || string.IsNullOrWhiteSpace(specialPieceLength.ToString()) || specialPieceLength < 2 || specialPieceLength >= victoryLength) {
                    Console.WriteLine($"Tamanho inválido. Tem que ser um número entre 2 e menor que número da sequência vencedora ({victoryLength}).");

                    Console.Write("\nQual é o tamanho da peça? ");
                    isValidInput = int.TryParse(Console.ReadLine(), out specialPieceLength);
                }

                Console.Write("Qual é a quantidade de peças? ");
                isValidInput = int.TryParse(Console.ReadLine(), out int specialPieceQuantity);

                while (!isValidInput || string.IsNullOrWhiteSpace(specialPieceQuantity.ToString()) || specialPieceQuantity < 1) {
                    Console.WriteLine($"Quantidade inválida. Tem que haver pelo menos 1 peça.");

                    Console.Write("\nQual é a quantidade de peças? ");
                    isValidInput = int.TryParse(Console.ReadLine(), out specialPieceQuantity);
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
            if (Board.Grid[Board.Rows - 1, column] != null) {
                Console.WriteLine("\nColuna completa.");

                return;
            }

            if (specialPiece == null) {
                for (int i = 0; i < Board.Rows; i++) {
                    if (Board.Grid[i, column] == null) {
                        Board.Grid[i, column] = CurrentPlayer;

                        break;
                    }
                }

            } else {
                if (specialPiece.Direction == SpecialPieceDirection.Left) {
                    if (column + 1 - specialPiece.Length < 0) {
                        Console.WriteLine($"\nNão é possível colocar a peça especial [{specialPiece.TranslatedDirection()}] - Tamanho: {specialPiece.Length} na coluna {column + 1}.");

                        return;
                    }

                    for (int j = column; j >= column - specialPiece.Length + 1; j--) {
                        if (Board.Grid[Board.Rows - 1, j] != null) {
                            Console.WriteLine($"\nNão pode colocar a peça especial nesta coluna pois a {j + 1}ª coluna já está completa.");

                            return;
                        }
                    }

                    for (int i = column; i >= column - specialPiece.Length + 1; i--) {
                        int targetRow = 0;

                        for (int row = 0; row < Board.Rows; row++) {
                            if (Board.Grid[row, i] == null) {
                                targetRow = row;

                                break;
                            }
                        }

                        Board.Grid[targetRow, i] = CurrentPlayer;
                    }

                } else if (specialPiece.Direction == SpecialPieceDirection.Right) {
                    if (column + specialPiece.Length > Board.Columns) {
                        Console.WriteLine($"\nNão é possível colocar a peça especial [{specialPiece.TranslatedDirection()}] - Tamanho: {specialPiece.Length} na coluna {column + 1}.");

                        return;
                    }

                    for (int j = 0; j < specialPiece.Length; j++) {
                        if (Board.Grid[Board.Rows - 1, j] != null) {
                            Console.WriteLine($"\nNão pode colocar a peça especial nesta coluna pois a {j + 1}ª coluna já está completa.");

                            return;
                        }
                    }

                    for (int i = column; i <= column + specialPiece.Length - 1; i++) {
                        int targetRow = 0;

                        for (int row = 0; row < Board.Rows; row++) {
                            if (Board.Grid[row, i] == null) {
                                targetRow = row;

                                break;
                            }
                        }

                        Board.Grid[targetRow, i] = CurrentPlayer;
                    }
                }

                specialPiece.DecreaseQuantity();
            }

            Console.WriteLine("\nPeça colocada.");

            ShowGameBoard();

            Player? gameStatus = CheckGameStatus();

            if (gameStatus == null) {
                Players.Enqueue(Players.Dequeue());
                CurrentPlayer = Players.Peek();

                return;
            }

            IsGameOnGoing = false;
            Players.ToList().ForEach(player => player.SpecialPieces.Clear());

            if (gameStatus.Name == "draw") {
                Players.ToList().ForEach((player) => player.SetStatistics(StatisticType.Draw));

                Console.WriteLine("\nJogo empatado!");

                return;
            }

            CurrentPlayer.SetStatistics(StatisticType.Victory);

            Players.Where((player) => player.Name != CurrentPlayer.Name).ToList().ForEach((player) => player.SetStatistics(StatisticType.Defeat));

            Console.WriteLine($"\nJogo terminado, venceu: {gameStatus}.");

            return;
        }

        private Player? CheckGameStatus() {
            int victoryLength = Board.VictoryLength;

            for (int row = 0; row <= Board.Rows - victoryLength; row++) {
                for (int column = 0; column < Board.Columns; column++) {
                    // Vertical
                    bool isVerticalVictory = true;

                    for (int i = 1; i < victoryLength; i++) {
                        if (Board.Grid[row, column] != Board.Grid[row + i, column]) {
                            isVerticalVictory = false;

                            break;
                        }
                    }

                    if (isVerticalVictory) {
                        return Board.Grid[row, column];
                    }

                    // Horizontal
                    if (column <= Board.Columns - victoryLength) {
                        bool isHorizontalVictory = true;

                        for (int i = 1; i < victoryLength; i++) {
                            if (Board.Grid[row, column] != Board.Grid[row, column + i]) {
                                isHorizontalVictory = false;

                                break;
                            }
                        }

                        if (isHorizontalVictory) {
                            return Board.Grid[row, column];
                        }
                    }

                    // Diagonal (direita)
                    if (column <= Board.Columns - victoryLength && row <= Board.Rows - victoryLength) {
                        bool isDiagonalRightVictory = true;

                        for (int i = 1; i < victoryLength; i++) {
                            if (Board.Grid[row, column] != Board.Grid[row + i, column + i]) {
                                isDiagonalRightVictory = false;

                                break;
                            }
                        }

                        if (isDiagonalRightVictory) {
                            return Board.Grid[row, column];
                        }
                    }

                    // Diagonal (esquerda)
                    if (column >= victoryLength - 1 && row <= Board.Rows - victoryLength) {
                        bool isDiagonalLeftVictory = true;

                        for (int i = 1; i < victoryLength; i++) {
                            if (Board.Grid[row, column] != Board.Grid[row + i, column - i]) {
                                isDiagonalLeftVictory = false;

                                break;
                            }
                        }

                        if (isDiagonalLeftVictory) {
                            return Board.Grid[row, column];
                        }
                    }
                }
            }

            // Se não estiver empatado, o jogo continua
            for (int row = 0; row < Board.Rows; row++) {
                for (int column = 0; column < Board.Columns; column++) {
                    if (Board.Grid[row, column] == null) {
                        return null;
                    }
                }
            }

            // Empate
            return new Player("draw", "");
        }

        public void GameDetails()
        {
            if (!IsGameOnGoing)
            {
                Console.WriteLine("\nNão está a decorrer nenhum jogo. Utilize 'ij' para iniciar um.");

                return;
            }

            Console.WriteLine($"\nTamanho da grelha: {Board.Columns}x{Board.Rows}");

            Console.WriteLine("\nJogadores:");
            List<Player> players = Players.OrderBy(player => player.Name).Select(player => player).ToList();
            foreach (Player player in players)
            {
                Console.WriteLine($"\n- {player}\n");

                foreach (SpecialPiece specialPiece in player.SpecialPieces)
                {
                    Console.WriteLine($"  * {specialPiece}");
                }
            }
        }
        
        public void Forfeit() 
        {
            Console.Write($"\n'{CurrentPlayer.Name}', tem a certeza que quer desistir do jogo? [s/n]: ");

            if (!((Console.ReadLine() ?? "") == "s")) {
                return;
            }

            Player otherPlayer = Players.First(player => player != CurrentPlayer);

            CurrentPlayer.SetStatistics(StatisticType.Defeat);

            otherPlayer.SetStatistics(StatisticType.Victory);

            IsGameOnGoing = false;
            Players.ToList().ForEach(player => player.SpecialPieces.Clear());

            Console.WriteLine($"\n'{CurrentPlayer.Name}' desistiu do jogo! Jogo terminado e '{otherPlayer.Name}' venceu a partida.");
        }

        public void ShowGameBoard() {
            Console.WriteLine();

            int maxRowLength = Board.Rows.ToString().Length;
            int maxColumnLength = Board.Columns.ToString().Length;

            Console.Write(new string(' ', maxRowLength + 1));

            for (int j = 0; j < Board.Columns; j++) {
                Console.Write($"{j + 1}".PadRight(maxColumnLength + 1));
            }

            Console.WriteLine();

            for (int i = 0; i < Board.Rows; i++) {
                string paddedRowNumber = $"{i + 1}".PadLeft(maxRowLength);

                Console.Write(paddedRowNumber + " ".PadRight(maxRowLength - paddedRowNumber.Length + 1));

                for (int j = 0; j < Board.Columns; j++) {
                    string symbol = Board.Grid[Board.Rows - 1 - i, j]?.Symbol ?? "-";

                    Console.Write(symbol.PadRight(maxColumnLength + 1));
                }

                Console.WriteLine();
            }
        }

        public bool HasPlayer(string playerName) {
            return Players.Where((player) => player.Name == playerName.Trim().ToLower()).Any();
        }
    }
}