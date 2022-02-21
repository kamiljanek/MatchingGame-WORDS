using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingGame_WORDS
{
    internal interface IGame
    {
        public int GuessChances { get; set; }
        public string LvlName { get; set; }
        public int NumberOfWords { get; set; }
    }
}
