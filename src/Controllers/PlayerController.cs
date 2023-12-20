using n_in_row.src.Models;

namespace n_in_row.src.Controllers
{
    internal class PlayerController() {
        public List<Player> PlayerList { get; private set; } = [];

        public void AddPlayer(Player player)
        {
            if (player != null)
            {
                PlayerList.Add(player);
                Console.WriteLine($"Player {player.Name} added to the list.");
            }
            else
            {
                Console.WriteLine("Cannot add a null player to the list.");
            }
        }

        public void RemovePlayer(Player player)
        {
            if (PlayerList.Contains(player))
            {
                PlayerList.Remove(player);
                Console.WriteLine($"Player {player.Name} removed from the list.");
            }
            else
            {
                Console.WriteLine($"Player {player.Name} not found in the list.");
            }
        }
    }
}
