using Microsoft.VisualStudio.TestTools.UnitTesting;
using Helpfy;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Helpfy.Tests
{
    [TestClass()]
    public class DictionaryOnlineTests
    {
        [TestMethod()]
        public void MeaningsAsyncTest()
        {
            var dictionary = new DictionaryOnline();
            Assert.IsNotNull(dictionary);
            var response = dictionary.MeaningsAsync("Test").Result;
            Assert.AreEqual("a procedure intended to establish the quality, performance, or reliability of something, especially before it is taken into widespread use.", response.FirstOrDefault().meanings[0].definitions[0].definition);
        }
    }
}