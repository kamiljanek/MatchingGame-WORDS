using System;
using System.Collections.Generic;

namespace MatchingGame_WORDS
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Title();
            Menu.MainMenu();
           
        }
        internal static void Title()
        {
            string headTitle = "MATCHING GAME - WORDS";
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth - headTitle.Length) / 2, Console.CursorTop); //centering text
            Console.WriteLine(headTitle);

            Console.WriteLine("");
        }
    }
}
