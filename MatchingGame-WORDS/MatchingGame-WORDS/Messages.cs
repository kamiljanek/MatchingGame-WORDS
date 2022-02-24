using System;

namespace MatchingGame_WORDS
{
    public static class Messages
    {
        public static void ShowTitle()
        {
            string headTitle = "MATCHING GAME - WORDS";
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth - headTitle.Length) / 2, Console.CursorTop); //centering text
            Console.WriteLine($"{headTitle}\n");
        }
        public static void ShowMainMenu()
        {
            Console.WriteLine("1 - Easy");
            Console.WriteLine("2 - Hard");
            Console.Write("SELECT THE DIFFICULTY LEVEL:");
        }
        public static void ShowGameOverMenu()
        {
            Console.WriteLine("1 - PLAY AGAIN");
            Console.WriteLine("2 - SAVE YOUR SCORE");
            Console.WriteLine("3 - SHOW 10 BEST SCORES\n");
            Console.WriteLine("4 - CLOSE GAME");
            Console.Write("\nSELECT OPTION: ");
        }
        public static void ShowException(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("PRESS ANY KEY TO CONTINUE...");
            Console.ReadKey();
        }
    }
}
