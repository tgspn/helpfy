using Microsoft.VisualStudio.TestTools.UnitTesting;
using Helpfy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpfy.Tests
{
    [TestClass()]
    public class ASCIIArtTests
    {
        [TestMethod()]
        public void ConvertTest()
        {
            ASCIIArt aSCIIArt = new ASCIIArt();
            Assert.IsNotNull(aSCIIArt);

            var response = aSCIIArt.Convert(@"Assets/Images/marguerite.jpg");
            Assert.IsNotNull(response);
            Assert.IsFalse(string.IsNullOrWhiteSpace(response));    
        }
    }
}