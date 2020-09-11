using System;
using FluentAssertions;
using NSubstitute;
using RPS_Game1.Game;
using TechTalk.SpecFlow;

namespace RPS_Games1.Specs.Steps
{
    public class GameContext
    {
        public GamePlay  Game { get; set; }

        public GameContext()
        {
        }

    }

    [Binding]
    public class BestOfThreeGamePlaySteps
    {
        public GameContext Context { get; }

        public BestOfThreeGamePlaySteps(GameContext context)
        {
            Context = context;
        }

        [Given(@"a game is started with two players")]
        public void GivenAGameIsStartedWithTwoPlayers()
        {
            Context.Game = new BestOfThreeGamePlay();
        }

        [When(@"the round is a tie")]
        public void WhenTheRoundIsATie()
        {
            var round = Substitute.ForPartsOf<Round>(Moves.Undefined, Moves.Undefined);
            round.WhoWon().Returns(0);

            Context.Game.PostRound(round);
        }

        [When(@"Player (.*) wins the round")]
        public void WhenPlayerWinsTheRound(int winner)
        {
            var round = Substitute.ForPartsOf<Round>(Moves.Undefined, Moves.Undefined);
            round.WhoWon().Returns(winner);


            Context.Game.PostRound(round);
        }

        [Then(@"Player (.*) is the winner")]
        public void ThenPlayerWinsTheRound(int winner)
        {
            Context.Game.TheWinnerIs().Should().Be(winner);

        }

        [Then(@"Still no winner")]
        public void ThenStillNoWinner()
        {
            Context.Game.TheWinnerIs().Should().Be(0);
        }

    }
}
