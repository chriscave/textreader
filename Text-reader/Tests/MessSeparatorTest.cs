using NUnit.Framework;
using System;
using Textreader;
namespace MessageSeparatorTest
{
    [TestFixture()]
    public class MSTest
    {
        [Test()]
        public void TestCase()
        {
            Message message = new Message("hello, Hello heLLo / hellO!");
            string[] arraymessage = message.SeparateMessage();
            Word word = new Word("hello");
            int expected = 4;

            word.CountWords(arraymessage);

            int actual = word.Counter;
            Assert.AreEqual(expected,actual,0.5, "Incorrectly partitioning message");

        }
    }
}
