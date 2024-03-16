namespace n_in_row.src {
    internal class Constants {
        public const int MAX_PLAYING_PLAYERS = 2;
        public const int MIN_BOARD_COLUMNS = 1;
        public const int MIN_BOARD_ROWS = 1;
        public const int MIN_VICTORY_LENGTH = 1;

        public static string[] ALLOWED_SYMBOLS = [
                "x",
                "o",
                "0",
                "1",
                "+",
                "-",
                "@",
                "#",
                ",",
                ".",
                "_",
                "`",
                "´",
                "^",
                "~",
                "*",
            ];

         public static Dictionary<string, string> OPTION_MAP = new() {
                { "rj", "Registar jogador" },
                { "ej", "Remover jogador" },
                { "lj", "Listar jogadores" },
                { "ij", "Iniciar jogo" },
                { "dj", "Detalhes de jogo" },
                { "d", "Desistir" },
                { "cp", "Colocar peça" },
                { "v", "Estado atual da grelha" },
                { "sair", "Sair" }
            };
    }
}
