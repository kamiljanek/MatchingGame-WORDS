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
            Console.WriteLine("Select the difficulty level:");
            Console.WriteLine("Easy - 1");
            Console.WriteLine("Hard - 2");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    lvl = 1;
                    game = new Game(lvl);
                    game.SetGame(words);
                    game.StartGame();
                    return;

                case "2":
                    lvl = 2;
                    game = new Game(lvl);
                    game.SetGame(words);
                    game.StartGame();
                    return;

                default:
                    Console.WriteLine("WRONG INPUT... TRY AGAIN...");
                    MainMenu();
                    break;
            }
        }


    }
}
