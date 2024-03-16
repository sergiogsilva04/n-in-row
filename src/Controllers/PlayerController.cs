using n_in_row.src.Models;
using System.Text;

namespace n_in_row.src.Controllers
{
    internal class PlayerController() {
        public Dictionary<string, Player> PlayerDictionary { get; private set; } = [];

        public void RegisterPlayer() {
            Console.Write("\nDigite o nome do jogador: ");
            string playerName = Console.ReadLine() ?? "";

            while (string.IsNullOrWhiteSpace(playerName.Trim())) {
                Console.WriteLine($"\nO nome '{playerName}' é inválido.");

                Console.Write("\nDigite o nome do jogador: ");
                playerName = Console.ReadLine() ?? "";
            }

            if (HasPlayer(playerName)) {
                Console.WriteLine($"\nO jogador '{playerName}' já está registado.");

                return;
            }

            Console.WriteLine("\nSímbolos possíveis:");

            Array.ForEach(Constants.ALLOWED_SYMBOLS, (symbol) => Console.Write($"[{symbol}] "));

            Console.Write("\n\nDigite o símbolo do jogador: ");
            string playerSymbol = Console.ReadLine() ?? "";

            while (string.IsNullOrWhiteSpace(playerSymbol.Trim()) || !Constants.ALLOWED_SYMBOLS.Contains(playerSymbol)) {
                Console.WriteLine($"\nO símbolo '{playerSymbol}' é inválido.");

                Console.Write("\nDigite o símbolo do jogador: ");
                playerSymbol = Console.ReadLine() ?? "";
            }

            Player player = new(playerName, playerSymbol);

            PlayerDictionary.Add(player.Name.Trim().ToLower(), player);

            Console.WriteLine($"\nO jogador {player} foi registado com sucesso.");
        }

        public void RemovePlayer(Game? currentGame) {
            Console.Write("\nDigite o nome do jogador a remover: ");
            string playerName = Console.ReadLine() ?? "";

            if (!HasPlayer(playerName)) {
                Console.WriteLine($"\nO jogador '{playerName}' não está registado.");

                return;
            }

            if (currentGame != null && currentGame.HasPlayer(playerName)) {
                Console.WriteLine($"\nO jogador '{playerName}' está em jogo.");

                return;
            }

            PlayerDictionary.Remove(playerName.Trim().ToLower());

            Console.WriteLine($"\nO jogador '{playerName}' foi removido com sucesso.");
        }
        

        public void ShowPlayerList(Game? currentGame) {
            if (PlayerDictionary.Count <= 0) {
                Console.WriteLine("\nA lista de jogadores está vazia.");

                return;
            }

            StringBuilder playerClassification = new("\n");

            Array.ForEach(PlayerDictionary.ToArray(), (player) => {
                playerClassification.Append($"{(currentGame != null && currentGame.HasPlayer(player.Key) ? "« EM JOGO » " : "")}{player.Value} [{player.Value.TotalGamesPlayed()} {(player.Value.TotalGamesPlayed() == 1 ? "jogo" : "jogos")}]");
                playerClassification.Append($" ({player.Value.GetStatistics(player.Value.Victories)}% vitórias - {player.Value.Victories})");
                playerClassification.Append($" ({player.Value.GetStatistics(player.Value.Draws)}% empates - {player.Value.Draws})");
                playerClassification.Append($" ({player.Value.GetStatistics(player.Value.Defeats)}% derrotas - {player.Value.Defeats})");

                Console.WriteLine(playerClassification);

                playerClassification.Clear();
            });
        }

        public bool HasPlayer(string name) {
            return PlayerDictionary.ContainsKey(name.Trim().ToLower());
        }

        public bool HasPlayer(Player player) {
            return PlayerDictionary.ContainsKey(player.Name.Trim().ToLower());
        }

        public Player GetPlayer(string name) {
            return PlayerDictionary[name.Trim().ToLower()];
        }
    }
}
