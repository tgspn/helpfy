using Microsoft.VisualStudio.TestTools.UnitTesting;
using Helpfy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helpfy.Tests
{
    [TestClass()]
    public class Base64CodeTests
    {
        [TestMethod()]
        public void EncodeTest()
        {
            Base64Code base64 = new Base64Code();
            Assert.IsNotNull(base64);
            Assert.AreEqual("T2zDoSwgbXVuZG8h", base64.Encode("Olá, mundo!"));
        }
        [TestMethod()]
        public void LeviathanFragmentEncodeTest()
        {
            Base64Code base64 = new Base64Code();
            Assert.IsNotNull(base64);
            Assert.AreEqual("TWFuIGlzIGRpc3Rpbmd1aXNoZWQsIG5vdCBvbmx5IGJ5IGhpcyByZWFzb24sIGJ1dCBieSB0aGlzIHNpbmd1bGFyIHBhc3Npb24gZnJvbSBvdGhlciBhbmltYWxzLCB3aGljaCBpcyBhIGx1c3Qgb2YgdGhlIG1pbmQsIHRoYXQgYnkgYSBwZXJzZXZlcmFuY2Ugb2YgZGVsaWdodCBpbiB0aGUgY29udGludWVkIGFuZCBpbmRlZmF0aWdhYmxlIGdlbmVyYXRpb24gb2Yga25vd2xlZGdlLCBleGNlZWRzIHRoZSBzaG9ydCB2ZWhlbWVuY2Ugb2YgYW55IGNhcm5hbCBwbGVhc3VyZS4=", base64.Encode(@"
Man is distinguished, not only by his reason, but by this singular passion from other animals, which is a lust of the mind, that by a perseverance of delight in the continued and indefatigable generation of knowledge, exceeds the short vehemence of any carnal pleasure.".Trim()));
        }
        [TestMethod()]
        public void MaEncodeTest()
        {
            Base64Code base64 = new Base64Code();
            Assert.IsNotNull(base64);
            Assert.AreEqual("TWE=", base64.Encode("Ma"));
        }
        [TestMethod()]
        public void DencodeTest()
        {
            Base64Code base64 = new Base64Code();
            Assert.IsNotNull(base64);
            Assert.AreEqual("Olá, mundo!", base64.Decode("T2zDoSwgbXVuZG8h"));
        }
        [TestMethod()]
        public void LeviathanFragmentDencodeTest()
        {
            Base64Code base64 = new Base64Code();
            Assert.IsNotNull(base64);
            Assert.AreEqual(@"
Man is distinguished, not only by his reason, but by this singular passion from other animals, which is a lust of the mind, that by a perseverance of delight in the continued and indefatigable generation of knowledge, exceeds the short vehemence of any carnal pleasure.".Trim(), base64.Decode("TWFuIGlzIGRpc3Rpbmd1aXNoZWQsIG5vdCBvbmx5IGJ5IGhpcyByZWFzb24sIGJ1dCBieSB0aGlzIHNpbmd1bGFyIHBhc3Npb24gZnJvbSBvdGhlciBhbmltYWxzLCB3aGljaCBpcyBhIGx1c3Qgb2YgdGhlIG1pbmQsIHRoYXQgYnkgYSBwZXJzZXZlcmFuY2Ugb2YgZGVsaWdodCBpbiB0aGUgY29udGludWVkIGFuZCBpbmRlZmF0aWdhYmxlIGdlbmVyYXRpb24gb2Yga25vd2xlZGdlLCBleGNlZWRzIHRoZSBzaG9ydCB2ZWhlbWVuY2Ugb2YgYW55IGNhcm5hbCBwbGVhc3VyZS4="));
        }
        [TestMethod()]
        public void MaDencodeTest()
        {
            Base64Code base64 = new Base64Code();
            Assert.IsNotNull(base64);
            Assert.AreEqual("Ma", base64.Decode("TWE="));
        }
        [TestMethod()]
        public void MDencodeTest()
        {
            Base64Code base64 = new Base64Code();
            Assert.IsNotNull(base64);
            Assert.AreEqual("M", base64.Decode("TQ=="));
        }
    }
}