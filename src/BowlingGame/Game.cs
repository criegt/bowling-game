using System.Linq;

namespace BowlingGame
{
    public class Game
    {
        private readonly Frame[] _frames = new Frame[10];
        private int _currentFrameIndex;

        public int Score => _frames.Sum(f => f.Score);

        public void Roll(int pins)
        {
            var roll = new Roll(pins);

            if (_frames[0] is null)
            {
                _frames[_currentFrameIndex] = new Frame(roll);
                return;
            }

            var currentFrame = _frames[_currentFrameIndex];

            if (!currentFrame.IsCompleted)
            {
                currentFrame.AddRoll(roll);
                return;
            }

            _frames[_currentFrameIndex + 1] = currentFrame.CreateNext(roll, _currentFrameIndex++ == 8);
        }
    }
}
