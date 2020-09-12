using System.Threading.Tasks;
using FluentAssertions;
using RPS_Game1.Game;
using Xunit;

namespace RPS_Games1.Specs.OtherTests
{
    public class ComputerPlayerTests
    {
        private ComputerPlayer SUT { get; }

        public ComputerPlayerTests()
        {
            SUT = new ComputerPlayer();
        }

        [Fact]
        public async Task WhenGetNextMoveShouldNeverBeUndefined()
        {
            for (int i = 0; i < 100; i++)
            {
                var result = await SUT.GetNextMove();

                result.Should().NotBe(Moves.Undefined);
            }
        }
    }
}