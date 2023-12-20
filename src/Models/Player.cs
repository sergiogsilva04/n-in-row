namespace n_in_row.src.Models {
    internal class Player(string name, string symbol, string color) {
        public string Name { get; private set; } = name;
        public string Symbol { get; private set; } = symbol;
        public string Color { get; private set; } = color;
        public int Victories { get; private set; } = 0;
        public int Draws { get; private set; } = 0;
        public int Loses { get; private set; } = 0;

        public int TotalGamesPlayed()
        {
            return Victories + Draws + Loses;
        }
    }
}
