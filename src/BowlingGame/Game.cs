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
                    if (IsStrike(rollCount))
                    {
                        score += 10 + GetBonusForStrike(rollCount);
                        rollCount++;
                    }
                    else if (IsSpare(rollCount))
                    {
                        score += 10 + GetBonusForSpare(rollCount);
                        rollCount += 2;
                    }
                    else
                    {
                        score += GetPinsKnockedDownInFrame(rollCount);
                        rollCount += 2;
                    }
                }

                return score;
            }
        }

        public void Roll(int pins)
        {
            _rolls[_currentRoll++] = pins;
        }

        private bool IsStrike(int rollCount)
        {
            return _rolls[rollCount] == 10;
        }

        private bool IsSpare(int rollCount)
        {
            return _rolls[rollCount] + _rolls[rollCount + 1] == 10;
        }

        private int GetBonusForSpare(int rollCount)
        {
            return _rolls[rollCount + 2];
        }

        private int GetBonusForStrike(int rollCount)
        {
            return _rolls[rollCount + 1] + _rolls[rollCount + 2];
        }

        private int GetPinsKnockedDownInFrame(int rollCount)
        {
            return _rolls[rollCount] + _rolls[rollCount + 1];
        }
    }
}
