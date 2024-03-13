using n_in_row.src.Models;
using System.Numerics;

namespace n_in_row.src.Controllers
{
    internal class PlayerController() {
        public Dictionary<string, Player> PlayerDictionary { get; private set; } = [];

        public void AddPlayer(Player player) {
            if (HasPlayer(player.Name)) {
                Console.WriteLine($"\nO jogador '{player.Name}' já está registado.");

                return;
            }

            PlayerDictionary.Add(player.Name.Trim().ToLower(), player);

            Console.WriteLine($"\nO jogador [{player.Symbol}] '{player.Name}' foi registado com sucesso.");
        }

        public void RemovePlayer(string playerName) {
            if (!HasPlayer(playerName)) {
                Console.WriteLine($"\nO jogador '{playerName}' não está registado.");

                return;
            }

            PlayerDictionary.Remove(playerName);

            Console.WriteLine($"\nO jogador '{playerName}' foi removido com sucesso.");
        }

        public bool HasPlayer(string name) {
            return PlayerDictionary.ContainsKey(name.Trim().ToLower());
        }

        public bool HasPlayer(Player player) {
            return PlayerDictionary.ContainsKey(player.Name.Trim().ToLower());
        }
    }
}
