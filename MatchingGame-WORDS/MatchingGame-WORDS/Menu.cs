using System;
using System.Collections.Generic;
using System.Linq;

namespace MatchingGame_WORDS
{
    public class Menu
    {
        public void MainMenu()
        {
            var gameData = new GameData();
            var gameFactory = new GameFactory();
            var txtFileWords = gameData.FileReader("words.txt");
            Title();
            Console.WriteLine("1 - Easy");
            Console.WriteLine("2 - Hard");
            Console.Write("SELECT THE DIFFICULTY LEVEL:");
            try
            {
                int userInput = Convert.ToInt32(Console.ReadLine());
                gameFactory.CreateGameWithDifficultyLvlAsInt(userInput, txtFileWords);
            }
            catch (Exception)
            {
                MainMenu();
            }


        }
        internal static void Title()
        {
            string headTitle = "MATCHING GAME - WORDS";
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth - headTitle.Length) / 2, Console.CursorTop); //centering text
            Console.WriteLine($"{headTitle}\n");
        }
        internal void GameOverMenu()
        {
            Title();
            var score = new Score();
            var gameData = new GameData();
            Console.WriteLine("1 - PLAY AGAIN");
            Console.WriteLine("2 - SAVE YOUR SCORE");
            Console.WriteLine("3 - SHOW 10 BEST SCORES\n");
            Console.WriteLine("TO CLOSE GAME PRESS \"c\"");
            Console.Write("\nSELECT OPTION: ");

            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    MainMenu();
                    break;

                case "2":
                    Title();
                    score.SaveForm();
                    gameData.SaveScore(score);
                    break;

                case "3":
                    Title();
                    var bestScores = gameData.JsonFileReader("10bestScores.json");
                    score.ShowBestScores(bestScores);
                    Console.WriteLine("\nTO CONTINUE PRESS ANY BUTTON...");
                    Console.ReadLine();
                    break;

                case "c":
                    return;

                default:
                    break;
            }
            GameOverMenu();
        }




    }
}
