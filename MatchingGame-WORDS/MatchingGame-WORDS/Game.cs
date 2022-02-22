using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingGame_WORDS
{
    internal class Game
    {
        private string displayDistance = "{0, -12}";


        public static string UserShootA;
        public static string UserShootB;
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
        public List<WordElement> helper = new List<WordElement> { new WordElement("a", "a") };

        public int GuessChances { get; set; }
        public string LvlName { get; private set; }
        public int NumberOfWords { get; private set; }

        private Random random = new Random();
        private void SetGameWords(List<string> mainWords)
        {
            var list = mainWords.OrderBy(x => random.Next()).Take(NumberOfWords).ToList();
            GameWords = list;
        }
        private void SetGameWordsShuffled(List<string> words)
        {
            GameWordsShuffled = words.OrderBy(x => random.Next()).ToList();
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
        internal void SetGame(List<string> mainWords)
        {
            SetGameWords(mainWords);
            SetGameWordsShuffled(GameWords);
            SetWordElements();
            SetWordElementsShuffled();
        }
        internal void DisplayHeaderGame()
        {

            Console.WriteLine($"Level:{LvlName}");
            Console.WriteLine($"Guess chances: {GuessChances}");
            Console.WriteLine("");
            Console.Write("  ");
            for (int i = 1; i <= WordElements.Count; i++)
            {
                Console.Write(displayDistance, i);
            }
            Console.WriteLine("");
        }
        private void DisplayRow(string rowName, List<WordElement> wordElements, string userInput)
        {
            Console.Write($"{rowName} ");

            for (int i = 0; i < wordElements.Count; i++)
            {
                if (wordElements[i].Id == userInput)
                {
                    Console.Write(displayDistance, wordElements[i].Value);
                }
                else if (MatchedWords.Find(x => x.Value == wordElements[i].Value) != null)
                {

                    Console.Write(displayDistance, wordElements[i].Value);
                }
                else
                {
                    Console.Write(displayDistance, wordElements[i].HiddenValue);
                }
            }
            Console.WriteLine("");
        }
        private void DashedLine()
        {
            Console.WriteLine("");
            string footer = string.Concat(Enumerable.Repeat("------------", NumberOfWords));
            Console.WriteLine(footer);
        }
        internal void DisplayGame()
        {
            Program.Title();
            DashedLine();
            DisplayHeaderGame();
            DisplayRow("A", WordElements, UserShootA);
            DisplayRow("B", WordElementsShuffled, UserShootB);
            DashedLine();
        }
        private void AddMatchingWordToList()
        {
            var matchWordA = WordElements.Find(x => x.Id == Game.UserShootA);
            var matchWordB = WordElementsShuffled.Find(x => x.Id == Game.UserShootB);
            if (matchWordA.Value == matchWordB.Value)
            {
                MatchedWords.Add(matchWordA);
            }
        }
        internal void ResetUserShoots()
        {
            Game.UserShootA = null;
            Game.UserShootB = null;
        }
        private void OneRound()
        {
            UserShootA = PartOfRound("A", WordElements);
            UserShootB = PartOfRound("B", WordElementsShuffled);
            DisplayGame();
            Console.WriteLine("Press button to start next round...");
            Console.ReadLine();
        }
        private string PartOfRound(string partRoundName, List<WordElement> wordElements)
        {
            DisplayGame();
            Console.Write($"Input \"{partRoundName}\" and column number e.g {partRoundName}3: ");
            var userShoot = UserInputAndCheck(wordElements);
            return userShoot;
        }
        private string UserInputAndCheck(List<WordElement> wordElements)
        {
            var userInput = Console.ReadLine();
            while (wordElements.Find(x => x.Id == userInput) == null)
            {
                Console.WriteLine("WRONG INPUT");
                userInput = Console.ReadLine();
            }
            return userInput;
        }
        internal void StartGame()
        {
            while (GuessChances > 0 && MatchedWords.Count <= NumberOfWords)
            {
                OneRound();
                AddMatchingWordToList();
                ResetUserShoots();
                GuessChances--;
            }
            GameOver();
        }
        internal void GameOver()
        {
            if (GuessChances <= 0)
            {
                Console.WriteLine("YOU LOOSE...");
            }
            else
            {
                Console.WriteLine("YOU WIN...");
            }

            Console.WriteLine("PRESS ANY BUTTON TO PLAY AGAIN");
            Console.ReadLine();
            Menu.MainMenu();
        }
    }
}
