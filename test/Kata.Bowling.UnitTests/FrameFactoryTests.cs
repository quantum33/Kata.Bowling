using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata.Bowling.UnitTests
{
    [TestClass]
    public class FrameFactoryTests
    {
        [TestMethod]
        public void CreateIf_True_NotNullFrame()
        {
            var result = FrameFactory.CreateIf(true, 0);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Rank);
        }

        [TestMethod]
        public void CreateIf_False_Null()
        {
            var result = FrameFactory.CreateIf(false, 0);
            Assert.IsNull(result);
        }
    }
}