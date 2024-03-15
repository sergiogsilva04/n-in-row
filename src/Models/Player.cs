namespace n_in_row.src.Models {
    public enum StatisticType {
        Victory,
        Draw,
        Defeat
    }

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

        public void SetStatistics(StatisticType statisticType) {
            switch (statisticType) {
                case StatisticType.Victory:
                    Victories++;

                    break;

                case StatisticType.Draw:
                    Draws++;

                    break;

                case StatisticType.Defeat:
                    Defeats++;

                    break;
            }
        }

        public double GetStatistics(int statistic) {
            if (statistic <= 0) {
                return 0;
            }

            return Math.Round((double)statistic / TotalGamesPlayed() * 100);
        }

        public void AddSpecialPiece(SpecialPiece specialPiece) {
            SpecialPieces.Add(specialPiece);
        }

        public override string ToString() {
            return $"[{Symbol}] '{Name}'";
        }

        public bool Equals(Player? other) {
            if (other == null) {
                return false;
            }

            return Name == other.Name;
        }
    }
}