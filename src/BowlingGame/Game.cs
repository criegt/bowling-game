namespace BowlingGame
{
    public class Game
    {
        private int _score;

        public int Score => _score;

        public void Roll(int pins) => _score += pins;
    }
}
