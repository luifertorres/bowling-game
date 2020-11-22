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
            RollMany(20, 0);

            Assert.Equal(0, _game.Score);
        }

        [Fact]
        public void TestAllOnes()
        {
            RollMany(20, 1);

            Assert.Equal(20, _game.Score);
        }

        [Fact]
        public void TestOneSpare()
        {
            RollSpare();
            _game.Roll(3);
            RollMany(17, 0);

            Assert.Equal(16, _game.Score);
        }

        [Fact]
        public void TestOneStrike()
        {
            RollStrike();
            _game.Roll(3);
            _game.Roll(4);
            RollMany(16, 0);

            Assert.Equal(24, _game.Score);
        }

        private void RollMany(int rolls, int pins)
        {
            for (var rollCount = 0; rollCount < rolls; rollCount++)
            {
                _game.Roll(pins);
            }
        }

        private void RollSpare()
        {
            _game.Roll(5);
            _game.Roll(5);
        }

        private void RollStrike()
        {
            _game.Roll(10);
        }
    }
}
