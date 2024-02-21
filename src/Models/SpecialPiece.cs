namespace n_in_row.src.Models {
    /*enum SpecialPieceDirection {
        Horizontal,
        Vertical,
        Diagonal
    }*/
    internal class SpecialPiece(String direction, int length) {
        public String Direction { get; private set; } = direction;
        public int Length { get; private set; } = length;

        public override string ToString() {
            return $"{Direction}: {Length}";
        }
    }
}