using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingGame_WORDS
{
    internal class Game : IGame
    {
        internal Game(int choosenLvl)
        {

            if (choosenLvl == 1)
            {
                GuessChances = 10;
                LvlName = "Easy";
                NumberOfWords = 4;
                MatchedWords = helper;
            }
            else if (choosenLvl == 2)
            {
                GuessChances = 15;
                LvlName = "Hard";
                NumberOfWords = 8;
                MatchedWords = helper;
            }
        }
        public List<string> GameWords { get; private set; }
        public List<string> GameWordsShuffled { get; private set; }
        public List<WordElement> WordElements { get; private set; }
        public List<WordElement> WordElementsShuffled { get; private set; }
        public List<WordElement> MatchedWords { get; set; }
        public List<WordElement> helper = new List<WordElement>{new WordElement("a", "a")};
        private string distance = "{0, -12}";
        public static string UserShootA;
        public static string UserShootB;

        public int GuessChances { get; set; }
        public string LvlName { get; set; }
        public int NumberOfWords { get; set; }

        private Random random = new Random();
        private void SetGameWords(List<string> mainWords)
        {
            var list = mainWords.OrderBy(x => random.Next()).Take(NumberOfWords).ToList();
            GameWords = list;
        }
        private void SetWordElements()
        {
            List<WordElement> words = new List<WordElement>();
            for (int i = 0; i < GameWords.Count; i++)
            {
                words.Add(new WordElement($"A{i + 1}", GameWords[i]));
            }
            WordElements = words;
        }
        private void SetWordElementsShuffled()
        {
            List<WordElement> words = new List<WordElement>();
            for (int i = 0; i < GameWordsShuffled.Count; i++)
            {
                words.Add(new WordElement($"B{i + 1}", GameWordsShuffled[i]));
            }
            WordElementsShuffled = words;
        }

        private void SetGameWordsShuffled(List<string> words)
        {
            GameWordsShuffled = words.OrderBy(x => random.Next()).ToList();
        }

        internal void SetGame(List<string> mainWords)
        {
            SetGameWords(mainWords);
            SetGameWordsShuffled(GameWords);
            //SetRowA(GameWords);
            //SetRowB(GameWordsShuffled);
            SetWordElements();
            SetWordElementsShuffled();
        }
        internal void PlayGame()
        {
            Console.Clear();
            DisplayHeader();
            Console.Write($"A ");
            DisplayRow(WordElements, UserShootA);
            Console.WriteLine("");
            Console.Write($"B ");
            DisplayRow(WordElementsShuffled, UserShootB);
            DisplayFooter();
        }

        private static void DisplayFooter()
        {
            Console.WriteLine("");
            Console.WriteLine("-----------------------------");
        }

        private void DisplayRow(List<WordElement> wordElements, string userInput)
        {
            for (int i = 0; i < wordElements.Count; i++)
            {
                if (wordElements[i].Id == userInput)
                {
                    Console.Write(distance, wordElements[i].Value);
                }
                else if (MatchedWords.Find(x => x.Value == wordElements[i].Value) != null)
                {

                    Console.Write(distance, wordElements[i].Value);
                }
                else
                {
                    //Console.Write($"{wordElements[i].HiddenValue}");
                    Console.Write(distance, wordElements[i].HiddenValue);
                }
            }
        }

        internal void DisplayHeader()
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine($"Level:{LvlName}");
            Console.WriteLine($"Guess chances: {GuessChances}");
            Console.WriteLine("");
            Console.Write("  ");
            for (int i = 1; i <= WordElements.Count; i++)
            {
                Console.Write(distance, i);
            }
            Console.WriteLine("");
        }
        internal void GameEnd()
        {
            if (GuessChances == 0 && MatchedWords.Count == NumberOfWords)
            {
                Console.WriteLine("YOU LOOSE...");
            }
            Console.WriteLine("YOU WIN...");
            Console.WriteLine("PRESS ANY BUTTON TO PLAY AGAIN");
            Console.ReadLine();
            Menu.MainMenu();
        }
        internal void ResetUserShoots()
        {
            Game.UserShootA = null;
            Game.UserShootB = null;
        }
    }
}
