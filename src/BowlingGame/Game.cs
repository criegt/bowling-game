namespace BowlingGame
{
    public class Game
    {
        private const int Spare = 10;
        private readonly int[] _rolls = new int[21];
        private int _currentRoll;

        public int Score
        {
            get
            {
                var score = 0;
                var frameIndex = 0;

                for (var frame = 0; frame < Spare; frame++)
                {
                    if (IsSpare(frameIndex))
                    {
                        score += Spare + _rolls[frameIndex + 2];
                    }
                    else
                    {
                        score += _rolls[frameIndex] + _rolls[frameIndex + 1];
                    }

                    frameIndex += 2;
                }

                return score;
            }
        }

        public void Roll(int pins) => _rolls[_currentRoll++] = pins;

        private bool IsSpare(int frameIndex)
            => _rolls[frameIndex] + _rolls[frameIndex + 1] == Spare;
    }
}
