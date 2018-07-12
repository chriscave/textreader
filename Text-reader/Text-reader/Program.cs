using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Textreader
{
    public class Word
    {
        private string word;
        public int Counter { get; private set; }
        public void CountWords(string[] message)
        {
            foreach (string m in message)
            {
                if (m == word)
                {
                    Counter++;
                }
            }
        }
        public Word(string w)
        {
            word = w;
            Counter = 0;
        }
        public override string ToString()
        {
            return word + ": " + Counter;
        }

    }
    public class Message
    {
        private string message;
        public string[] NoDuplicates { get; private set; }
        private static string[] separator = { " ", ".", ",", ";", ":", "\"", 
            "\t", "\n", "\\", "/", "(", ")", "{", "}", "[", "]", "?", "!",
            "0","1","2","3","4","5","6","7","8","9"};

        public string[] SeparateMessage()
        {
            string[] submessage = message.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            return submessage.Select(s => s.ToLower()).ToArray();
        }
        public Message(string text)
        {
            message = text;
            NoDuplicates = SeparateMessage().Distinct().ToArray();
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            string path = "textfile.txt"; //include name of text file here. The text file should be saved in the Debug folder
            using (StreamReader sr = new StreamReader(path))
            {
                while (sr.EndOfStream != true)
                {
                    Message message = new Message(sr.ReadLine());
                    string[] submessage = message.SeparateMessage();
                    string[] messageNoDuplicates = message.NoDuplicates;
                    int m = messageNoDuplicates.Length;
                    Word[] obj = new Word[m];
                    for (int i = 0; i < m; i++)
                    {
                        obj[i] = new Word(messageNoDuplicates[i]);
                        obj[i].CountWords(submessage);
                    }

                    foreach (Word w in obj)
                    {
                        Console.WriteLine("\n" + w.ToString());
                    }
                }

                sr.Close();
            }
        }
    }
}
