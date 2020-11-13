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
            for (var rollCount = 0; rollCount < 20; rollCount++)
            {
                _game.Roll(0);
            }

            Assert.Equal(0, _game.Score);
        }
    }
}
