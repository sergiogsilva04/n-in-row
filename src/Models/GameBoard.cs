namespace n_in_row.src.Models {
    internal class GameBoard {
        private int _lines, _columns;

        public int Lines {
            get => _lines;
            set => _lines = value;
        }

        public int Columns {
            get => _columns;
            set => _columns = value;
        }

        public GameBoard(int lines, int columns) {
            Lines = lines;
            Columns = columns;
        }
    }
}
