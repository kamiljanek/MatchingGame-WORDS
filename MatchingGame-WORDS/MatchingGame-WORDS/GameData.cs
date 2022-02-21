using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingGame_WORDS
{
    internal class GameData
    {
        private const string filePath = "words.txt";



        public List<string> FileReader()
        {
            List<string> wordsFromFile = new List<string>();
            using (StreamReader sr = File.OpenText(filePath))
            {
                string readedLine;
                while ((readedLine = sr.ReadLine()) != null)
                {
                    wordsFromFile.Add(readedLine);
                }
            };
            return wordsFromFile;
        }
      
    }
}
