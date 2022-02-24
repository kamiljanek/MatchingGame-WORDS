using System;
using System.Collections.Generic;
using System.Linq;

namespace MatchingGame_WORDS
{
    public class Game
    {
        private string displayElementsDistance = "{0, -12}";
        public List<WordElement> MatchedWords = new List<WordElement> { new WordElement("empty", "empty") };
        public static DateTime TimerStart;
        public static DateTime TimerStop;
        public static int WinningScore;

        public static string UserShootA;
        public static string UserShootB;
        public Game(int guessChances, string lvlName, int numberOfWords, List<string> txtFileWords)
        {
            GuessChances = guessChances;
            LvlName = lvlName;
            NumberOfWords = numberOfWords;
            TxtFileWords = txtFileWords;
        }

        public List<string> TxtFileWords { get; private set; }
        public List<string> GameWords { get; private set; }
        public List<string> GameWordsShuffled { get; private set; }
        public List<WordElement> WordElements { get; private set; }
        public List<WordElement> WordElementsShuffled { get; private set; }

        public int GuessChances { get; set; }
        public string LvlName { get; private set; }
        public int NumberOfWords { get; private set; }

        private Random random = new Random();
        private void SetGameWords()
        {
            var list = TxtFileWords.OrderBy(x => random.Next()).Take(NumberOfWords).ToList();
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
        private void SetGame()
        {
            SetGameWords();
            SetGameWordsShuffled(GameWords);
            SetWordElements();
            SetWordElementsShuffled();
        }
        public void DisplayHeaderGame()
        {

            Console.WriteLine($"Level:{LvlName}");
            Console.WriteLine($"Guess chances: {GuessChances}\n");
            Console.Write("  ");
            for (int i = 1; i <= WordElements.Count; i++)
            {
                Console.Write(displayElementsDistance, i);
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
                    Console.Write(displayElementsDistance, wordElements[i].Value);
                }
                else if (MatchedWords.Find(x => x.Value == wordElements[i].Value) != null)
                {

                    Console.Write(displayElementsDistance, wordElements[i].Value);
                }
                else
                {
                    Console.Write(displayElementsDistance, wordElements[i].HiddenValue);
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
        public void DisplayGame()
        {
            Messages.ShowTitle();
            DashedLine();
            DisplayHeaderGame();
            DisplayRow("A", WordElements, UserShootA);
            DisplayRow("B", WordElementsShuffled, UserShootB);
            DashedLine();
        }
        private void AddMatchingWordToList()
        {
            var matchWordA = WordElements.Find(x => x.Id == UserShootA);
            var matchWordB = WordElementsShuffled.Find(x => x.Id == UserShootB);
            if (matchWordA.Value == matchWordB.Value)
            {
                MatchedWords.Add(matchWordA);
            }
        }
        public void ResetUserShoots()
        {
            UserShootA = null;
            UserShootB = null;
        }
        private void OneRound()
        {
            UserShootA = PartOfRound("A", WordElements);
            UserShootB = PartOfRound("B", WordElementsShuffled);
            DisplayGame();
            Console.WriteLine("Press any button to continue...");
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
        public int StartGame()
        {
            SetGame();
            TimerStart = DateTime.Now;
            while (GuessChances > 0 && MatchedWords.Count <= NumberOfWords)
            {
                OneRound();
                AddMatchingWordToList();
                ResetUserShoots();
                GuessChances--;
            }
            TimerStop = DateTime.Now;
            GameOver();
            return GuessChances;
        }
        public void GameOver()
        {
            WinningScore = GuessChances;
            if (GuessChances <= 0)
            {
                Console.WriteLine("YOU LOOSE...");
            }
            else
            {
                Console.WriteLine("YOU WIN...");
            }
            Console.WriteLine("PRESS ANY BUTTON TO CONTINUE...");
            Console.ReadLine();
        }
    }
}
