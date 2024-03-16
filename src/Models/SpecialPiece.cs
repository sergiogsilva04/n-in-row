using System.Xml.Linq;

namespace n_in_row.src.Models {
    enum SpecialPieceDirection {
        Left,
        Right,
    }

    internal class SpecialPiece(SpecialPieceDirection direction, int length, int quantity) : IEquatable<Object> {
        public SpecialPieceDirection Direction { get; private set; } = direction;
        public int Length { get; private set; } = length;
        public int Quantity { get; private set; } = quantity;

        public void AddQuantity(int quantity) {
            Quantity += quantity;
        }

        public string TranslatedDirection() {
            return directionTranslations[Direction];
        }

        public override string ToString() {
            return $"{(Quantity > 0 ? Quantity : "« ESGOTADO »")}x [{TranslatedDirection()}] - Tamanho: {Length}";
        }

        private Dictionary<SpecialPieceDirection, string> directionTranslations = new() {
            { SpecialPieceDirection.Left, "Esquerda" },
            { SpecialPieceDirection.Right, "Direita" }
        };

        public override bool Equals(Object? other) {
            if (other == null || GetType() != other.GetType()) {
                return false;
            }

            return Direction == ((SpecialPiece) other).Direction && Length == ((SpecialPiece)other).Length;
        }

        public override int GetHashCode() {
            return HashCode.Combine(Direction, Length);
        }
    }
}