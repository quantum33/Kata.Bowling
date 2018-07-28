using Kata.Bowling;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Kata.Bowling.UnitTests
{
    [TestClass]
    public class RankedFramesExtentionsTests
    {
        [TestMethod]
        public void AddTo_NonNullInstance_ListContainsTheInstance()
        {
            var instance = new Frame(0);
            var frames = new List<Frame>();

            instance.AddTo(frames);

            Assert.IsTrue(frames.Contains(instance));
        }

        [TestMethod]
        public void AddTo_NullInstance_ListNotContainNullInstance()
        {
            Frame instance = null;
            var frames = new List<Frame>();

            instance.AddTo(frames);

            Assert.IsFalse(frames.Contains(null));
        }
    }
}
