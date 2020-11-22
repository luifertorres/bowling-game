namespace BowlingGame
{
    public class Game
    {
        private readonly int[] _rolls = new int[21];
        private int _currentRoll;

        public int Score
        {
            get
            {
                var score = 0;
                var rollCount = 0;

                for (var frames = 0; frames < 10; frames++)
                {
                    if (IsSpare(rollCount))
                    {
                        score += 10 + _rolls[rollCount + 2];
                    }
                    else
                    {
                        score += _rolls[rollCount] + _rolls[rollCount + 1];
                    }

                    rollCount += 2;
                }

                return score;
            }
        }

        public void Roll(int pins)
        {
            _rolls[_currentRoll++] = pins;
        }

        private bool IsSpare(int rollCount)
        {
            return _rolls[rollCount] + _rolls[rollCount + 1] == 10;
        }
    }
}
