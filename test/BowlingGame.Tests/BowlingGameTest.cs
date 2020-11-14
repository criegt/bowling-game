using Xunit;

namespace BowlingGame.Tests
{
    public class BowlingGameTest
    {
        [Fact]
        public void TestGutterGame()
        {
            var game = new Game();

            for (var rollCount = 0; rollCount < 20; rollCount++)
            {
                game.Roll(0);
            }

            Assert.Equal(0, game.Score);
        }
    }
}
