using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kata.Bowling;

namespace Kata.Bowling.UnitTests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void GetFrameCount_Return1()
        {
            var game = new Game();

            game.Roll(1);
            game.Roll(4);
            Assert.AreEqual(1, game.GetFrameCount()); // Forget AAA: Assertion everywhere! => free style baby!! \o/ :D

            game.Roll(4);
            game.Roll(5);
            Assert.AreEqual(2, game.GetFrameCount()); // Forget AAA: Assertion everywhere! => free style baby!! \o/ :D

            game.Roll(6);
            game.Roll(4);
            Assert.AreEqual(3, game.GetFrameCount()); // Forget AAA: Assertion everywhere! => free style baby!! \o/ :D

            game.Roll(5);
            game.Roll(5);
            Assert.AreEqual(4, game.GetFrameCount()); // Forget AAA: Assertion everywhere! => free style baby!! \o/ :D

            game.Roll(10);
            Assert.AreEqual(5, game.GetFrameCount()); // Forget AAA: Assertion everywhere! => free style baby!! \o/ :D
        }

        [TestMethod]
        public void GetScore_Return133()
        {
            var game = new Game();

            game.Roll(1);
            game.Roll(4);

            game.Roll(4);
            game.Roll(5);

            game.Roll(6);
            game.Roll(4);

            game.Roll(5);
            game.Roll(5);

            game.Roll(10);

            game.Roll(0);
            game.Roll(1);

            game.Roll(7);
            game.Roll(3);

            game.Roll(6);
            game.Roll(4);

            game.Roll(10);

            game.Roll(2);
            game.Roll(8);
            game.Roll(6);

            Assert.AreEqual(133, game.GetScore());
        }
    }
}
