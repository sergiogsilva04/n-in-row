using n_in_row.src.Models;

namespace n_in_row.src.Controllers
{
    internal class GameController
    {
        private int player1Wins;
        private int player2Wins;
        private int player1Losses;
        private int player2Losses;
        private int ties;

        public GameController()
        {
            player1Wins = 0;
            player2Wins = 0;
            player1Losses = 0;
            player2Losses = 0;
            ties = 0;
        }
        public void RecordResult(Player? winner)
        {
            if (winner == null)
            {
                ties++;
                Console.WriteLine("Empate");
            }
            else
            {
                if (winner == Player1)
                {
                    player1Wins++;
                    player2Losses++;
                    Console.WriteLine($"{Player1.Name} ganhou!");
                }
                else
                {
                    player2Wins++;
                    player1Losses++;
                    Console.WriteLine($"{Player2.Name} ganhou!");
                }
            }
        }

        public void DisplayGameHistory()
        {
            Console.WriteLine("Game History:");
            Console.WriteLine($"{Player1.Name} Wins: {player1Wins}, Losses: {player1Losses}");
            Console.WriteLine($"{Player2.Name} Wins: {player2Wins}, Losses: {player2Losses}");
            Console.WriteLine($"Ties: {ties}");
        }
    }
}
