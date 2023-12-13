using System;
using System.Collections.Generic;

namespace n_in_row.src.Controllers
{
    internal class PlayerController
    {
        private List<Player> _playerList;

        public PlayerController()
        {
            _playerList = new List<Player>();
        }

        public List<Player> PlayerList
        {
            get { return _playerList; }
        }

        public void AddPlayer(Player player)
        {
            if (player != null)
            {
                _playerList.Add(player);
                Console.WriteLine($"Player {player.Name} added to the list.");
            }
            else
            {
                Console.WriteLine("Cannot add a null player to the list.");
            }
        }

        public void RemovePlayer(Player player)
        {
            if (_playerList.Contains(player))
            {
                _playerList.Remove(player);
                Console.WriteLine($"Player {player.Name} removed from the list.");
            }
            else
            {
                Console.WriteLine($"Player {player.Name} not found in the list.");
            }
        }
    }
}
