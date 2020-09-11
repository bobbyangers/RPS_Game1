using System;
using System.Threading.Tasks;

namespace RPS_Game1.Game
{
    public enum Moves
    {
        Undefined,
        Rock,
        Paper,
        Scissors
    }

    public interface IPlayer
    {
        Task<Moves> GetNextMove();
    }

    public class DefaultPlayer : IPlayer
    {
        public virtual Task<Moves> GetNextMove()
        {
            return Task.FromResult(Moves.Undefined);
        }
    }


    public class HumanPlayer : DefaultPlayer
    {
        private IInputProvider InputProvider { get; }

        public HumanPlayer(IInputProvider inputProvider)
        {
            InputProvider = inputProvider;
        }

        public override Task<Moves> GetNextMove()
        {
            var m = InputProvider.GetLine();

            var result = m switch
            {
                "R" => Moves.Rock,
                "P" => Moves.Paper,
                "S" => Moves.Scissors,
                _ => throw new InvalidInputException()
            };

            return Task.FromResult(result);
        }
    }

    /// <summary>
    /// The Random Computer player should automatically select one R, P, S at random
    /// </summary>
    public class ComputerPlayer : DefaultPlayer
    {
        public override Task<Moves> GetNextMove()
        {
            var rnd = new Random();

            var resultInt = rnd.Next(1, 4);

            return Task.FromResult((Moves) resultInt);
        }
    }

    /// <summary>
    /// The tactical computer player should always select the choice that would beaten the last choice
    /// I does not need to take the other player's move into account
    /// i.e.
    ///   Rock => Paper
    ///   Scissors => Rock
    ///   Paper => Scissors
    /// </summary>
    public class TacticalComputerPlayer : ComputerPlayer
    {
        private Moves LastMove { get; set; }

        public TacticalComputerPlayer()
        {
            LastMove = Moves.Undefined;
        }

        public TacticalComputerPlayer(Moves lastMove)
        {
            LastMove = lastMove;
        }

        public override async Task<Moves> GetNextMove()
        {
            var result = LastMove switch
            {
                Moves.Undefined => await base.GetNextMove(),
                Moves.Rock => Moves.Paper,
                Moves.Paper => Moves.Scissors,
                Moves.Scissors => Moves.Rock,
                _ => LastMove
            };

            LastMove = result;

            return result;
        }
    }
}
