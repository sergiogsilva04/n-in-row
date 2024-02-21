using n_in_row.src.Models;

namespace n_in_row.src.Controllers
{
    internal class PlayerController() {
        public Dictionary<string, Player> PlayerDictionary { get; private set; } = [];

        public void AddPlayer(Player player) {
            if (!PlayerDictionary.ContainsKey(player.Name)) {
                Console.WriteLine($"Player '{player.Name}' is already in the dictionary.");

                return;
            }

            PlayerDictionary.Add(player.Name, player);

            Console.WriteLine($"Player {player.Name} added to the dictionary.");
        }

        public void RemovePlayer(Player player) {
            if (PlayerDictionary.ContainsKey(player.Name)) {
                PlayerDictionary.Remove(player.Name);
                Console.WriteLine($"Player {player.Name} removed from the dictionary.");
            } else {
                Console.WriteLine($"Player {player.Name} not found in the dictionary.");
            }
        }
    }
}
