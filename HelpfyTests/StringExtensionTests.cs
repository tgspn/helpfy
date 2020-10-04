using Microsoft.VisualStudio.TestTools.UnitTesting;
using Helpfy;
using System;
using System.Collections.Generic;
using System.Text;
using Helpfy;
namespace Helpfy.Tests
{
    [TestClass()]
    public class StringExtensionTests
    {
        [TestMethod()]
        public void ToRepeatTest()
        {
            Assert.AreEqual("===", "=".ToRepeat(3));
            Assert.AreEqual("******************************", "*".ToRepeat(30));
        }
    }
}