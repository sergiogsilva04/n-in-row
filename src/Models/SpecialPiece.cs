namespace n_in_row.src.Models {
    enum SpecialPieceDirection {
        Left,
        Right,
    }

    internal class SpecialPiece(SpecialPieceDirection direction, int length) {
        public SpecialPieceDirection Direction { get; private set; } = direction;
        public int Length { get; private set; } = length;

        public override string ToString() {
            return $"{Direction}: {Length}";
        }
    }
}