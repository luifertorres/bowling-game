﻿using Xunit;

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

        private void RollMany(int rolls, int pins)
        {
            for (var rollCount = 0; rollCount < rolls; rollCount++)
            {
                _game.Roll(pins);
            }
        }
    }
}
