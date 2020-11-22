using Xunit;

namespace BowlingGame.Tests
{
    public class BowlingGameTest
    {
        private readonly Game _game;

        public BowlingGameTest()
        {
            _game = new();
        }

        [Fact]
        public void TestGutterGame()
        {
            RollManyTimes(20, 0);
            Assert.Equal(0, _game.Score);
        }

        [Fact]
        public void TestAllOnes()
        {
            RollManyTimes(20, 1);
            Assert.Equal(20, _game.Score);
        }

        private void RollManyTimes(int timesToRoll, int pins)
        {
            for (var i = 0; i < timesToRoll; i++)
            {
                _game.Roll(pins);
            }
        }

        [Fact]
        public void TestOneSpare()
        {
            RollSpare();
            _game.Roll(3);
            RollManyTimes(17, 0);
            Assert.Equal(16, _game.Score);
        }

        private void RollSpare()
        {
            _game.Roll(5);
            _game.Roll(5); // Spare
        }
    }
}
