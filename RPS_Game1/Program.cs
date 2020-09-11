using System;
using System.Threading.Tasks;
using RPS_Game1.Game;

namespace RPS_Game1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to the RPS command line game.");

            var player1 = new HumanPlayer(new DefaultInputProvider());

            Console.Write("Please select your opponent 1=Random, 2=Tactical + [Enter]:");
            var opponent = Console.ReadLine();

            var player2 = opponent == "1" 
                ? new ComputerPlayer() : opponent == "2" 
                    ? new TacticalComputerPlayer() : throw new InvalidOperationException("") ;
            
            var game = new BestOfThreeGamePlay();

            var winner = 0;
            while (winner == 0)
            {
                var round = new Round(await player1.GetNextMove(), await player2.GetNextMove());

                Console.WriteLine(round.ToString());

                game.PostRound(round);
                winner = game.TheWinnerIs();
            }

            Console.WriteLine(winner == 1 ? "Congratulation, you won the game!!!" : "Sorry, you lost the game.");
        }
    }
}
