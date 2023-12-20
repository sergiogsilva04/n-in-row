using n_in_row.src.Models;
using System.Text;

namespace n_in_row {
    class Program {
        static void Main() {
            Console.OutputEncoding = Encoding.UTF8;

            Game currentGame = new Game(
                victoryLength: 4,
                new GameBoard(lines: 4, columns: 4),
                player1: new Player("Sérgio Silva", "S", "#fff"),
                player2: new Player("Francisco", "F", "#000")
            );

            do {
                Console.WriteLine($"É a vez do jogador: {currentGame.CurrentPlayer.Name}");
                Console.Write("Qual é a coluna que vai colocar a peça? ");
                int column = int.Parse(Console.ReadLine()!);

                while (column < 1 || column > currentGame.Board.Columns) {
                    Console.WriteLine($"Coluna inválida. Tem que ser um número entre 1 e {currentGame.Board.Columns}");

                    Console.Write("\nQual é a coluna que vai colocar a peça? ");
                    column = int.Parse(Console.ReadLine()!);
                }

                currentGame.Play(column - 1);

                Console.WriteLine();

            } while (!currentGame.IsGameFinished);
        }
    }
}