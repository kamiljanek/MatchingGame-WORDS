using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingGame_WORDS
{
    internal class Menu
    {

        internal static void MainMenu()
        {
            var gameData = new GameData();
            var words = gameData.FileReader();
            int lvl;
            Game game;
            Console.Write("Choose difficulty level (1, 2): ");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    lvl = 1;
                    game = new Game(lvl);
                    game.SetGame(words);
                    StartGame(game);
                    return;

                case "2":
                    lvl = 2;
                    game = new Game(lvl);
                    game.SetGame(words);
                    StartGame(game);
                    return;

                default:
                    Console.WriteLine("WRONG INPUT... TRY AGAIN...");
                    MainMenu();
                    break;
            }
        }

        private static void StartGame(Game game)
        {
            while (game.GuessChances != 0 || game.MatchedWords.Count == game.NumberOfWords)
            {
                RoundPlay(game);
                MatchingWordListCreator(game);
                game.ResetUserShoots();
                game.GuessChances--;
            }
            game.GameEnd();
        }

        private static void RoundPlay(Game game)
        {
            game.PlayGame();
            Game.UserShootA = Console.ReadLine();
            game.PlayGame();
            Game.UserShootB = Console.ReadLine();
            game.PlayGame();
            Console.WriteLine("Press button to start next round...");
            Console.ReadLine();
        }

        private static void MatchingWordListCreator(Game game)
        {
            var matchWordA = game.WordElements.Find(x => x.Id == Game.UserShootA);
            var matchWordB = game.WordElementsShuffled.Find(x => x.Id == Game.UserShootB);
            if (matchWordA.Value == matchWordB.Value)
            {
                game.MatchedWords.Add(matchWordA);
            }
        }

    }
}
