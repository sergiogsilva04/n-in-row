namespace n_in_row.src.Models {
    enum SpecialPieceDirection {
        Left,
        Right,
    }

    internal class SpecialPiece(SpecialPieceDirection direction, int length, int quantity) {
        public SpecialPieceDirection Direction { get; private set; } = direction;
        public int Length { get; private set; } = length;
        public int Quantity { get; private set; } = quantity;

        public override string ToString() {
            return $"[{Quantity} available] {Direction}: {Length}";
        }
    }
}