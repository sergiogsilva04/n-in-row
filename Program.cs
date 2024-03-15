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

                        bool keepPlaying;

                        do {
                            Console.WriteLine($"\nÉ a vez do jogador: {currentGame.CurrentPlayer}");

                            //*currentPlayerSpecialPieces = currentGame.CurrentPlayer.SpecialPieces;

                            //if (currentPlayerSpecialPieces.Count > 0) {
                            //    Console.Write("Utilizar peça especial? (s/n): ");

                            //    if (Console.ReadLine() == "s") {

                            //        Console.WriteLine();

                            //        Array.ForEach(currentPlayerSpecialPieces.ToArray(), Console.WriteLine);

                            //        Console.Write($"\nQual a peça a utilizar (número de 1 a {currentPlayerSpecialPieces.Count}): ");

                            //        selectedSpecialPiece = currentPlayerSpecialPieces[int.Parse(Console.ReadLine()!) - 1];
                            //    }
                            //}

                            Console.Write("\nQual é a coluna que vai colocar a peça? ");
                            int column = int.Parse(Console.ReadLine()!);

                            while (column <= 0 || column > currentGame.Board.Columns) {
                                Console.WriteLine($"Coluna inválida. Tem que ser um número entre 1 e {currentGame.Board.Columns}");

                                Console.Write("\nQual é a coluna que vai colocar a peça? ");
                                column = int.Parse(Console.ReadLine()!);
                            }

                            currentGame.Play(column - 1, null);

                            //*selectedSpecialPiece = null;*//*

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
            );

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