using System.Collections.Generic;

namespace MatchingGame_WORDS
{
    public class EasyGame : Game
    {
        public EasyGame(List<string> txtFileWords) : base(GuessChances, LvlName, NumberOfWords, txtFileWords)
        {

        }
        public const int GuessChances = 10;
        public const string LvlName = "Easy";
        public const int NumberOfWords = 1;

    }
}
