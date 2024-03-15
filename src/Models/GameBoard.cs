namespace n_in_row.src.Models {
    internal class GameBoard(int rows, int columns, int victoryLength) {
        public int Rows { get; private set; } = rows;
        public int Columns { get; private set; } = columns;
        public int VictoryLength { get; private set; } = victoryLength;
        public Player[,] Grid = new Player[rows, columns];
    }
}