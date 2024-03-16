using n_in_row.src;
using n_in_row.src.Controllers;
using n_in_row.src.Models;
using System.Text;

namespace n_in_row {
    class Program {
        static void Main() {
            Console.OutputEncoding = Encoding.UTF8;

            PlayerController playerController = new();
            string selectedOption;
            Game? currentGame = null;

            playerController.PlayerDictionary.Add("sergio", new Player("sergio", "x"));
            playerController.PlayerDictionary.Add("silva", new Player("silva", "o"));

            Queue<Player> testPlayers = new Queue<Player>();

            testPlayers.Enqueue(playerController.PlayerDictionary.First().Value);
            testPlayers.Enqueue(playerController.PlayerDictionary.Last().Value);

            Array.ForEach(testPlayers.ToArray(), (player) => {
                player.AddSpecialPiece(new SpecialPiece(SpecialPieceDirection.Left, 2, 1));
                player.AddSpecialPiece(new SpecialPiece(SpecialPieceDirection.Right, 3, 1));
            });

            currentGame = new(testPlayers, new GameBoard(3, 3, 3));

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
                        SelectedOptionInfo(Constants.OPTION_MAP[selectedOption]);

                        playerController.RegisterPlayer();

                        PressKeyToContinue();

                        break;

                    case "ej":
                        SelectedOptionInfo(Constants.OPTION_MAP[selectedOption]);

                        playerController.RemovePlayer(currentGame);

                        PressKeyToContinue();

                        break;

                    case "lj":
                        SelectedOptionInfo(Constants.OPTION_MAP[selectedOption]);

                        playerController.ShowPlayerList(currentGame);

                        PressKeyToContinue();

                        break;

                    case "ij":
                        SelectedOptionInfo(Constants.OPTION_MAP[selectedOption]);

                        currentGame = null;

                        if (playerController.PlayerDictionary.Count <= 0) {
                            Console.WriteLine("\nNão existem jogadores registados. Utilize 'rj' para registar um jogador.");

                            break;
                        }

                        if (currentGame != null) {
                            Console.WriteLine("\nJá existe um jogo a decorrer. Utilize 'cp' para jogar.");

                            break;
                        }

                        currentGame = Game.StartGame(playerController, currentGame);

                        PressKeyToContinue();

                        break;

                    case "dj":
                        SelectedOptionInfo(Constants.OPTION_MAP[selectedOption]);

                        break;

                    case "d":
                        SelectedOptionInfo(Constants.OPTION_MAP[selectedOption]);

                        break;

                    case "cp":
                        SelectedOptionInfo(Constants.OPTION_MAP[selectedOption]);

                        if (currentGame == null) {
                            Console.WriteLine("\nNão está a decorrer nenhum jogo. Utilize 'ij' para iniciar um.");

                            break;
                        }

                        bool keepPlaying, isValidInput;

                        do {
                            Console.WriteLine($"\nÉ a vez do jogador: {currentGame.CurrentPlayer}.");

                            List<SpecialPiece> currentPlayerSpecialPieces = currentGame.CurrentPlayer.SpecialPieces;
                            SpecialPiece? selectedSpecialPiece = null;

                            if (currentPlayerSpecialPieces.Count > 0) {
                                Console.Write("\nUtilizar peça especial? [s/n]: ");

                                if (Console.ReadLine() == "s") {
                                    Console.WriteLine();

                                    for (int i = 0; i < currentPlayerSpecialPieces.Count; i++) {
                                        Console.WriteLine($"« {i + 1} » {currentPlayerSpecialPieces[i]}");
                                    }

                                    Console.Write($"\nQual a peça a utilizar (número de 1 a {currentPlayerSpecialPieces.Count}): ");
                                    
                                    isValidInput = int.TryParse(Console.ReadLine(), out int selectedIndex);

                                    while (!isValidInput || selectedIndex <= 0 || selectedIndex > currentPlayerSpecialPieces.Count) {
                                        Console.WriteLine($"Seleção inválida. Tem que ser um número de 1 a {currentPlayerSpecialPieces.Count}.");

                                        Console.Write($"\nQual a peça a utilizar? ");
                                        isValidInput = int.TryParse(Console.ReadLine(), out selectedIndex);
                                    }

                                    selectedSpecialPiece = currentPlayerSpecialPieces[selectedIndex - 1];

                                    Console.WriteLine($"\nPeça especial selecionada: [{selectedSpecialPiece.TranslatedDirection()}] - Tamanho: {selectedSpecialPiece.Length}");
                                }
                            }

                            Console.Write("\nQual é a coluna que vai colocar a peça? ");
                            isValidInput = int.TryParse(Console.ReadLine(), out int column);

                            while (!isValidInput || column <= 0 || column > currentGame.Board.Columns) {
                                Console.WriteLine($"Coluna inválida. Tem que ser um número entre 1 e {currentGame.Board.Columns}");

                                Console.Write("\nQual é a coluna que vai colocar a peça? ");
                                isValidInput = int.TryParse(Console.ReadLine(), out column);
                            }

                            currentGame.Play(column - 1, selectedSpecialPiece);

                            if (!currentGame.IsGameOnGoing) {
                                break;
                            }

                            Console.Write("\nDeseja continuar a jogar? [s/n]: ");
                            keepPlaying = (Console.ReadLine() ?? "") == "s";

                        } while (keepPlaying);

                        if (!currentGame.IsGameOnGoing) {
                            currentGame = null;
                        }

                        PressKeyToContinue();

                        break;

                    case "v":
                        SelectedOptionInfo(Constants.OPTION_MAP[selectedOption]);

                        break;

                    case "sair":
                        SelectedOptionInfo(Constants.OPTION_MAP[selectedOption]);

                        Console.WriteLine("\nObrigado por jogar...\n\nDesenvolvido por:\n\nFrancisco Reis;\nRicardo Martins;\nSérgio Silva.");

                        break;

                    default:
                        Console.WriteLine("\nOpção inválida.");

                        break;
                }

            } while (selectedOption != "sair");
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