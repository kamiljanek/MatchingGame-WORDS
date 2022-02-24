using System;
using System.Collections.Generic;

namespace MatchingGame_WORDS
{
    public class GameFactory : IGameFactory
    {
        public Game CreateGameWithDifficultyLvlAsInt(int userInput, List<string> txtFileWords)
        {
            Game game;
            switch (userInput)
            {
                case 1:
                    game = CreateEasyGame(txtFileWords);
                    break;

                case 2:
                    game = CreateHardGame(txtFileWords);
                    break;

                default:
                    throw new ArgumentException();
            }
            return game;
        }

        public Game CreateHardGame(List<string> txtFileWords)
        {
            return new HardGame(txtFileWords);
        }

        public Game CreateEasyGame(List<string> txtFileWords)
        {
            return new EasyGame(txtFileWords);
        }
    }
}

