using NUnit.Framework;
using System;
using Textreader;

namespace WordCountTest
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void WCTest()
        {
            Word word = new Word("hello");
            string[] message = { "hello", "hello", "hello" };
            int expected = 3;

            word.CountWords(message);

            int actual = word.Counter;
            Assert.AreEqual(expected,actual,0.5, "Incorrectly counting words");

        }
    }
}
