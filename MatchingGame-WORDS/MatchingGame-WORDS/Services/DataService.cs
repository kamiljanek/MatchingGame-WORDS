using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace MatchingGame_WORDS.Services
{
    public class DataService
    {
        public string JsonScoreSerialized { get; private set; }
        public List<string> FileReader(string filePath)
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
        public List<Score> JsonFileReader(string filePath)
        {
            List<Score> linesFromFile = new List<Score>();
            using (StreamReader sr = File.OpenText(filePath))
            {
                string readedLine;
                while ((readedLine = sr.ReadLine()) != null)
                {
                    var score = JsonConvert.DeserializeObject<Score>(readedLine);
                    linesFromFile.Add(score);
                }
            };
            return linesFromFile;
        }
        public void SerializedScore(object obj)
        {
            JsonScoreSerialized = JsonConvert.SerializeObject(obj);
        }
        public void SaveScore(object obj)
        {
            SerializedScore(obj);
            using (StreamWriter sw = File.AppendText("10BestScores.json"))
            {
                sw.WriteLine(JsonScoreSerialized);
            };

        }
    }
}
