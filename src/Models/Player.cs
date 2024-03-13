namespace n_in_row.src.Models {
    internal class Player(string name, string symbol) : IEquatable<Player> {
        public string Name { get; private set; } = name;
        public string Symbol { get; private set; } = symbol;
        public List<SpecialPiece> SpecialPieces { get; private set; } = [];
        public int Victories { get; private set; } = 0;
        public int Draws { get; private set; } = 0;
        public int Defeats { get; private set; } = 0;

        public int TotalGamesPlayed() {
            return Victories + Draws + Defeats;
        }

        public double GetStatistic(int statistic) {
            if (TotalGamesPlayed() <= 0) {
                return 0;
            }

            return statistic / TotalGamesPlayed();
        }

        public void AddSpecialPiece(SpecialPiece specialPiece) {
            SpecialPieces.Add(specialPiece);
        }

        public override string ToString() {
            return Name;
        }

        public bool Equals(Player? other) {
            if (other == null) {
                return false;
            }

            return Name == other.Name;
        }
    }
}