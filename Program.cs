using n_in_row.src.Controllers;
using n_in_row.src.Models;
using System.Text;

namespace n_in_row {
    class Program {
        static void Main() {
            Console.OutputEncoding = Encoding.UTF8;

            PlayerController playerController = new();

            Player player1 = new("Sérgio Silva", "S");
            Player player2 = new("Francisco", "F");

            playerController.AddPlayer(player1);
            playerController.AddPlayer(player2);

            player1.AddSpecialPiece(new SpecialPiece(SpecialPieceDirection.Left, 3));
            player1.AddSpecialPiece(new SpecialPiece(SpecialPieceDirection.Left, 5));
            player1.AddSpecialPiece(new SpecialPiece(SpecialPieceDirection.Left, 1));

            Game currentGame = new(
                victoryLength: 4,
                new GameBoard(lines: 5, columns: 5),
                player1: player1,
                player2: player2
            );

            SpecialPiece? selectedSpecialPiece = null;

            do {
                Console.WriteLine($"É a vez do jogador: {currentGame.CurrentPlayer.Name}");

                Console.Write("Vai user peça especial? (s/n): ");

                List<SpecialPiece> currentPlayerSpecialPieces = currentGame.CurrentPlayer.SpecialPieces;

                if (Console.ReadLine() == "s") {
                    Array.ForEach(currentPlayerSpecialPieces.ToArray(), Console.WriteLine);

                    Console.Write($"Qual a peça a utilizar (número de 1 a {currentPlayerSpecialPieces.Count}): ");

                    selectedSpecialPiece = currentPlayerSpecialPieces[int.Parse(Console.ReadLine()!) - 1];
                }

                Console.Write("Qual é a coluna que vai colocar a peça? ");
                int column = int.Parse(Console.ReadLine()!);

                while (column < 1 || column > currentGame.Board.Columns) {
                    Console.WriteLine($"Coluna inválida. Tem que ser um número entre 1 e {currentGame.Board.Columns}");

                    Console.Write("\nQual é a coluna que vai colocar a peça? ");
                    column = int.Parse(Console.ReadLine()!);
                }

                currentGame.Play(column - 1, selectedSpecialPiece);

                Console.WriteLine();

            } while (!currentGame.IsGameOnGoing);
        }
    }
}