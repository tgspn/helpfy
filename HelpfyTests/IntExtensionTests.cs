using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Helpfy;

namespace Helpfy.Tests
{
    [TestClass()]
    public class IntExtensionTests
    {
        [TestMethod()]
        public void ToNegativeTest()
        {
            Assert.AreEqual(-1, 1.ToNegative());
            Assert.AreEqual(0, 0.ToNegative());
            Assert.AreEqual(-2, (-2).ToNegative());
        }
    }
}