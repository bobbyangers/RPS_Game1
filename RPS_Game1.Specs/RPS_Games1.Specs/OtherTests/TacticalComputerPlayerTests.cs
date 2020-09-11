using AutoFixture;
using FluentAssertions;
using NSubstitute;
using RPS_Game1.Game;
using System.Threading.Tasks;
using Xunit;

namespace RPS_Games1.Specs.OtherTests
{
    public class HumanPlayerTests
    {
        private HumanPlayer SUT { get; set; }

        private IFixture Fixture { get; }

        public HumanPlayerTests()
        {
            Fixture = new Fixture();

            var provider = Substitute.For<IInputProvider>();

            Fixture.Inject(provider);

            SUT = Fixture.Create<HumanPlayer>();
        }

        [Theory]
        [InlineData("R", Moves.Rock)]
        [InlineData("P", Moves.Paper)]
        [InlineData("S", Moves.Scissors)]
        public async Task WhenGetNextMoveAndXThenY(string input, Moves expected)
        {
            var provider = Fixture.Create<IInputProvider>();

            provider.GetLine().Returns(input);

            var result = await SUT.GetNextMove();

            result.Should().Be(expected);
        }

        [Fact]
        public void WhenGetNextMoveAndInputRandomThenException()
        {
            var provider = Fixture.Create<IInputProvider>();

            provider.GetLine().Returns(Fixture.Create<string>());

            Assert.ThrowsAsync<InvalidInputException>(async () => await SUT.GetNextMove());
        }
    }

    public class TacticalComputerPlayerTests
    {

        [Fact]
        public void WhenDefaultFirstMoveIsNotUndefined()
        {
            var sut = new TacticalComputerPlayer();

            var result = sut.GetNextMove();

            result.Should().NotBe(Moves.Undefined);
        }

        [Theory]
        [InlineData(Moves.Rock, Moves.Paper)]
        [InlineData(Moves.Paper, Moves.Scissors)]
        [InlineData(Moves.Scissors, Moves.Rock)]
        public async Task WhenLastMoveIsXThenExpectedY(Moves last, Moves expected)
        {
            var sut = new TacticalComputerPlayer(last);
            var result = await sut.GetNextMove();

            result.Should().Be(expected);

        }
    }
}
