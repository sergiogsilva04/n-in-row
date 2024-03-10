using System;
using System.Collections.Generic;
using n_in_row.src.Models;

namespace n_in_row.src.Controllers {
    internal class GameController {
        private static Dictionary<Player, int> victories = new Dictionary<Player, int>();
        private static Dictionary<Player, int> defeats = new Dictionary<Player, int>();

        public static void RegisterVictory(Player player) {
            if (victories.ContainsKey(player)) {
                victories[player]++;
            } else {
                victories[player] = 1;
            }
        }

        public static void RegisterDefeat(Player player) {
            if (defeats.ContainsKey(player)) {
                defeats[player]++;
            } else {
                defeats[player] = 1;
            }
        }

        public static int GetVictories(Player player) {
            if (victories.ContainsKey(player)) {
                return victories[player];
            } else {
                return 0;
            }
        }

        public static int GetDefeats(Player player) {
            if (defeats.ContainsKey(player)) {
                return defeats[player];
            } else {
                return 0;
            }
        }
    }
}