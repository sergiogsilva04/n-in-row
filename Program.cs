using n_in_row.src.Controllers;
using n_in_row.src.Models;
using System.Text;

namespace n_in_row {
    class Program {
        static void Main() {
            Console.OutputEncoding = Encoding.UTF8;

            string[] allowedSymbols = [
                "x",
                "o",
                "0",
                "1",
                "+",
                "-",
                "@",
                "#",
                ",",
                ".",
                "_",
                "`",
                "´",
                "^",
                "~",
                "*",
            ];

            Dictionary<string, string> optionMap = new() {
                { "rj", "Registar jogador" },
                { "ej", "Remover jogador" },
                { "lj", "Listar jogadores" },
                { "ij", "Iniciar jogo" },
                { "dj", "Detalhes de jogo" },
                { "d", "Desistir" },
                { "cp", "Colocar peça" },
                { "v", "Estado atual da grelha" },
                { "sair", "Sair" }
            };

            string selectedOption;
            PlayerController playerController = new();

            do {
                Console.WriteLine("\n|--------: N em linha :--------|");
                Console.WriteLine("|                              |");
                Console.WriteLine("|      Selecione uma opção     |");
                Console.WriteLine("|                              |");
                Console.WriteLine("|---------> Comandos <---------|");
                Console.WriteLine("| 'rj' - Registar jogador      |");
                Console.WriteLine("| 'ej' - Remover jogador       |");
                Console.WriteLine("| 'lj' - Listar jogadores      |");
                Console.WriteLine("| 'ij' - Iniciar jogo          |");
                Console.WriteLine("| 'dj' - Detalhes de jogo      |");
                Console.WriteLine("| 'd' - Desistir               |");
                Console.WriteLine("| 'cp' - Colocar peça          |");
                Console.WriteLine("| 'v' - Estado atual da grelha |");
                Console.WriteLine("|------------------------------|");
                Console.WriteLine("| 'sair' - Sair do programa    |");
                Console.WriteLine("|--------: N em linha :--------|");

                Console.Write("\nO que pretende fazer? ");
                selectedOption = (Console.ReadLine() ?? "").ToLower();

                switch (selectedOption) {
                    case "rj":
                        SelectedOptionInfo(optionMap[selectedOption]);

                        Console.Write("\nDigite o nome do jogador: ");
                        string playerName = Console.ReadLine() ?? "";

                        while (string.IsNullOrWhiteSpace(playerName.Trim())) {
                            Console.WriteLine($"\nO nome '{playerName}' é inválido.");

                            Console.Write("\nDigite o nome do jogador: ");
                            playerName = Console.ReadLine() ?? "";
                        }

                        if (playerController.HasPlayer(playerName)) {
                            Console.WriteLine($"\nO jogador '{playerName}' já está registado.");

                            break;
                        }

                        Console.WriteLine("\nSímbolos possíveis:");

                        Array.ForEach(allowedSymbols, (symbol) => Console.Write($"[{symbol}] "));

                        Console.Write("\n\nDigite o símbolo do jogador: ");
                        string playerSymbol = Console.ReadLine() ?? "";

                        while (string.IsNullOrWhiteSpace(playerSymbol.Trim()) || !allowedSymbols.Contains(playerSymbol)) {
                            Console.WriteLine($"\nO símbolo '{playerSymbol}' é inválido.");

                            Console.Write("\nDigite o símbolo do jogador: ");
                            playerSymbol = Console.ReadLine() ?? "";
                        }

                        playerController.AddPlayer(new(playerName, playerSymbol));

                        PressKeyToContinue();

                        break;

                    case "ej":
                        SelectedOptionInfo(optionMap[selectedOption]);

                        Console.Write("\nDigite o nome do jogador a remover: ");
                        string playerToRemove = Console.ReadLine() ?? "";

                        if (!playerController.HasPlayer(playerToRemove)) {
                            Console.WriteLine($"\nO jogador '{playerToRemove}' não está registado.");

                            break;
                        }

                        // TODO: VERIFICAR SE O JOGADOR ESTÁ NUM JOGO EM CURSO
                        if (!playerController.HasPlayer(playerToRemove)) {
                            Console.WriteLine($"\nO jogador '{playerToRemove}' não está registado.");

                            break;
                        }

                        playerController.RemovePlayer(playerToRemove);

                        PressKeyToContinue();

                        break;

                    case "lj":
                        SelectedOptionInfo(selectedOption);

                        if (playerController.PlayerDictionary.Count <= 0) {
                            Console.WriteLine("\nA lista de jogadores está vazia.");

                            break;
                        }

                        StringBuilder playerClassification = new StringBuilder();

                        Array.ForEach(playerController.PlayerDictionary.ToArray(), (player) => {
                            playerClassification.Append($"{player.Value.Name} [{player.Value.TotalGamesPlayed()} jogos]");
                            playerClassification.Append($" ({player.Value.GetStatistic(player.Value.Victories)}% vitórias - {player.Value.Victories})");
                            playerClassification.Append($" ({player.Value.GetStatistic(player.Value.Draws)}% empates - {player.Value.Draws})");
                            playerClassification.Append($" ({player.Value.GetStatistic(player.Value.Defeats)}% derrotas - {player.Value.Defeats})");

                            Console.WriteLine(playerClassification);

                            playerClassification.Clear();
                        });

                        PressKeyToContinue();

                        break;

                    case "ij":
                        SelectedOptionInfo(selectedOption);

                        break;

                    case "dj":
                        SelectedOptionInfo(selectedOption);

                        break;

                    case "d":
                        SelectedOptionInfo(selectedOption);

                        break;

                    case "cp":
                        SelectedOptionInfo(selectedOption);

                        break;

                    case "v":
                        SelectedOptionInfo(selectedOption);

                        break;

                    case "sair":
                        SelectedOptionInfo(selectedOption);

                        Console.WriteLine("\nObrigado por jogar...\n\nDesenvolvido por:\nFrancisco Reis;\nRicardo Martins;\nSérgio Silva.\n\n");

                        break;

                    default:
                        Console.WriteLine("\nOpção inválida.");

                        break;
                }

            } while (selectedOption != "sair");

            /*PlayerController playerController = new();

            Player player1 = new("Sérgio Silva", "S");
            Player player2 = new("Francisco", "F");

            playerController.AddPlayer(player1);
            playerController.AddPlayer(player2);

            Console.WriteLine();

            player1.AddSpecialPiece(new SpecialPiece(SpecialPieceDirection.Left, 3, 2));
            player1.AddSpecialPiece(new SpecialPiece(SpecialPieceDirection.Left, 5, 2));
            player1.AddSpecialPiece(new SpecialPiece(SpecialPieceDirection.Left, 1, 2));

            Game currentGame = new(
                victoryLength: 4,
                new GameBoard(lines: 5, columns: 5),
                player1: player1,
                player2: player2
            );*/

            /*SpecialPiece? selectedSpecialPiece = null;
            List<SpecialPiece> currentPlayerSpecialPieces = [];*/

            /*do {
                Console.WriteLine($"É a vez do jogador: {currentGame.CurrentPlayer.Name}");

                *//*currentPlayerSpecialPieces = currentGame.CurrentPlayer.SpecialPieces;

                if (currentPlayerSpecialPieces.Count > 0) {
                    Console.Write("Utilizar peça especial? (s/n): ");

                    if (Console.ReadLine() == "s") {

                        Console.WriteLine();

                        Array.ForEach(currentPlayerSpecialPieces.ToArray(), Console.WriteLine);

                        Console.Write($"\nQual a peça a utilizar (número de 1 a {currentPlayerSpecialPieces.Count}): ");

                        selectedSpecialPiece = currentPlayerSpecialPieces[int.Parse(Console.ReadLine()!) - 1];
                    }
                } *//*
 
                Console.Write("Qual é a coluna que vai colocar a peça? ");
                int column = int.Parse(Console.ReadLine()!);

                while (column < 1 || column > currentGame.Board.Columns) {
                    Console.WriteLine($"Coluna inválida. Tem que ser um número entre 1 e {currentGame.Board.Columns}");

                    Console.Write("\nQual é a coluna que vai colocar a peça? ");
                    column = int.Parse(Console.ReadLine()!);
                }

                currentGame.Play(column - 1, null);

                *//*selectedSpecialPiece = null;*//*

                Console.WriteLine();

            } while (currentGame.IsGameOnGoing);
        }*/
        }

        public static void PressKeyToContinue() {
            Console.WriteLine("\n|----------: N em linha :---------|");
            Console.WriteLine("|                                 |");
            Console.WriteLine("| Prima 'ENTER' para continuar... |");
            Console.WriteLine("|                                 |");
            Console.WriteLine("|----------: N em linha :---------|");

            Console.ReadLine();
        }

        public static void SelectedOptionInfo(string selectedOption) {
            Console.WriteLine("\n|--------: N em linha :--------|");
            Console.WriteLine("|                              |");

            int remainingSpaces = 30 - selectedOption.Length;
            int spacesOnEachSide = remainingSpaces / 2;

            string formattedLine = $"|{new string(' ', spacesOnEachSide)}{selectedOption}{new string(' ', remainingSpaces - spacesOnEachSide)}|";
            Console.WriteLine(formattedLine);

            Console.WriteLine("|                              |");
            Console.WriteLine("|--------: N em linha :--------|");
        }
    }
}