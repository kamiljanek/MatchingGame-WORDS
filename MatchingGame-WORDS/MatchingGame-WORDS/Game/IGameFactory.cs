using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingGame_WORDS
{
    public interface IGameFactory
    {
        Game CreateGameWithDifficultyLvlAsInt(int userInput, List<string> txtFileWords);
        Game CreateHardGame(List<string> txtFileWords);
        Game CreateEasyGame(List<string> txtFileWords);
    }
}
