namespace n_in_row.src.Models {
    internal class GameBoard {
        public int Lines { get; private set; }
        public int Columns { get; private set; }
        private Player[,] Board;

        public GameBoard(int lines, int columns) {
            Lines = lines;
            Columns = columns;

            Board = new Player[lines, columns];
        }

/*        public void ShowBoard() {
            for (int i = 0; i < Lines; i++) {
                for (int j = 0; j < Columns; j++) {
                    Board[i, j] = new Player("X");

                    Console.Write(Board[i, j]);
                }

                Console.WriteLine();
            }
        }*/
    }
}
