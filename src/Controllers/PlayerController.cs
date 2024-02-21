using n_in_row.src.Models;

namespace n_in_row.src.Controllers
{
    internal class PlayerController() {
        public List<Player> PlayerList { get; private set; } = [];

        public void AddPlayer(Player newPlayer)
        {
            if (PlayerList.Contains(newPlayer))
            {
                Console.WriteLine("The player is already in the list");

                return;
            }

            PlayerList.Add(newPlayer);

            Console.WriteLine($"Player {newPlayer} added to the list.");
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
