namespace RPS_Game1.Game
{
    public class Round
    {
        public Moves Move1 { get; }
        public Moves Move2 { get; }

        public Round(Moves move1, Moves move2)
        {
            Move1 = move1;
            Move2 = move2;
        }

        public virtual int WhoWon()
        {
            return Move1 switch
            {
                Moves.Rock => Move2 switch
                {
                    Moves.Scissors => 1,
                    Moves.Paper => 2,
                    _ => 0
                },
                Moves.Paper => Move2 switch
                {
                    Moves.Rock => 1,
                    Moves.Scissors => 2,
                    _ => 0
                },
                Moves.Scissors => Move2 switch
                {
                    Moves.Rock => 1,
                    Moves.Paper => 2,
                    _ => 0
                },
                _ => 0
            };
        }

        public override string ToString()
        {
            return $"Player1 played {Move1} | Player2 played {Move2} => Winner is {WhoWon()}";
        }
    }
}