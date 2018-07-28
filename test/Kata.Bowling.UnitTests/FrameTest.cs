using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata.Bowling.UnitTests
{
    [TestClass]
    public class FrameTests
    {
        [TestMethod]
        public void GetScore_1And4DownPins_Return5()
        {
            var frame = new Frame(1);
            frame.AddRoll(new Roll(1))
                 .AddRoll(new Roll(4));
            Assert.AreEqual(5, frame.GetScore(null));
        }

        [TestMethod]
        public void GetScore_IsSpareAndNextRollHas2PinsDown_Return12()
        {
            var frame = new Frame(1);
            frame.AddRoll(new Roll(5))
                 .AddRoll(new Roll(5));

            var nextRoll = new Roll(2);
            var nextFrame = new Frame(2).AddRoll(nextRoll);

            Assert.AreEqual(12, frame.GetScore(nextFrame));
        }

        [TestMethod]
        public void GetScore_IsStrikeAndNextFrameHas7PinsDown_Return17()
        {
            var frame = new Frame(1)
                            .AddRoll(new Roll(10));

            var nextFrame = new Frame(2)
                                .AddRoll(new Roll(3))
                                .AddRoll(new Roll(4));

            Assert.AreEqual(17, frame.GetScore(nextFrame));
        }

        [TestMethod]
        public void GetScore_IsSpareAndTenthFrameAndNextRollHas6PinsDown_Return16()
        {
            var frame = new Frame(1)
                            .AddRoll(new Roll(2))
                            .AddRoll(new Roll(8));

            var nextFrame = new Frame(2)
                                .AddRoll(new Roll(6));

            Assert.AreEqual(16, frame.GetScore(nextFrame));
        }
    }
}
