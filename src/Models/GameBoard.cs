namespace n_in_row.src.Models {
    internal class GameBoard(int lines, int columns) {
        public int Lines { get; private set; } = lines;
        public int Columns { get; private set; } = columns;
        public Player[,] Grid = new Player[lines, columns];
    }
}