namespace n_in_row.src.Models {
    internal class Slot {
        private int _positionX, _positionY;
        private Player? _player;

        public int PositionX {
            get => _positionX;
            set => _positionX = value;
        }

        public int PositionY {
            get => _positionY;
            set => _positionY = value;
        }

        public Player? Player {
            get => _player;
            set => _player = value;
        }

        public Slot(int positionX, int positionY) {
            _positionX = positionX;
            _positionY = positionY;
        }
    }
}
