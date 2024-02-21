namespace n_in_row.src.Models {
    internal class Player(string name, string symbol) : IEquatable<Player> {
        public string Name { get; private set; } = name;
        public string Symbol { get; private set; } = symbol;
        public List<SpecialPiece> SpecialPieces { get; private set; } = [];
        public int Victories { get; private set; } = 0;
        public int Draws { get; private set; } = 0;
        public int Loses { get; private set; } = 0;

        public int TotalGamesPlayed() {
            return Victories + Draws + Loses;
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