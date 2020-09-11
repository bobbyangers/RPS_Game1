using System.Collections.Generic;
using System.Linq;

namespace RPS_Game1.Game
{
    public class GamePlay
    {
        public virtual void PostRound(Round round) { }

        public virtual int TheWinnerIs()
        {
            return 0;
        }
    }
    
    public class BestOfThreeGamePlay : GamePlay
    {
        public List<int> RoundResult { get; }

        public BestOfThreeGamePlay()
        {
            RoundResult = new List<int>();
        }

        public override int TheWinnerIs()
        {
            return RoundResult.Count(x => x == 1) == 2 ? 1 
                : RoundResult.Count(x => x == 2) == 2 ? 2 
                : 0;
        }

        public override void PostRound(Round round)
        {
            var winner = round.WhoWon();

            if (winner != 0)
            {
                RoundResult.Add(winner);
            }
        }

    }
}
