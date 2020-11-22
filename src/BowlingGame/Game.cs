namespace BowlingGame
{
    public class Game
    {
        private const int Strike = 10;
        private readonly int[] _rolls = new int[21];
        private int _currentRoll;

        public int Score
        {
            get
            {
                var score = 0;
                var frameIndex = 0;

                for (var frame = 0; frame < Strike; frame++)
                {
                    if (IsStrike(frameIndex))
                    {
                        score += Strike + StikeBonus(frameIndex);
                        frameIndex++;
                    }
                    else if (IsSpare(frameIndex))
                    {
                        score += SpareBonus(frameIndex);
                        frameIndex += 2;
                    }
                    else
                    {
                        score += PinsInFrame(frameIndex);
                        frameIndex += 2;
                    }
                }

                return score;
            }
        }

        private bool IsStrike(int frameIndex)
        {
            return _rolls[frameIndex] == 10;
        }

        private int PinsInFrame(int frameIndex)
        {
            return _rolls[frameIndex] + _rolls[frameIndex + 1];
        }

        private int SpareBonus(int frameIndex)
        {
            return Strike + _rolls[frameIndex + 2];
        }

        private int StikeBonus(int frameIndex)
        {
            return _rolls[frameIndex + 1] + _rolls[frameIndex + 2];
        }

        public void Roll(int pins) => _rolls[_currentRoll++] = pins;

        private bool IsSpare(int frameIndex)
            => _rolls[frameIndex] + _rolls[frameIndex + 1] == Strike;
    }
}
