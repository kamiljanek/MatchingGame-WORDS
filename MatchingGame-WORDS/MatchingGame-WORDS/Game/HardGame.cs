using System.Collections.Generic;

namespace MatchingGame_WORDS
{
    public class HardGame : Game
    {
        public HardGame(List<string> txtFileWords) : base(GuessChances, LvlName, NumberOfWords, txtFileWords)
        {

        }
        public const int GuessChances = 15;
        public const string LvlName = "Hard";
        public const int NumberOfWords = 8;

    }
}
