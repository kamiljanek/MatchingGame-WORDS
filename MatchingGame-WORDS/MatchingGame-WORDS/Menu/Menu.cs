﻿using MatchingGame_WORDS.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MatchingGame_WORDS
{
    public class Menu : IMenu
    {
        private readonly DataService _dataService;
        private readonly Score _score;
        private readonly IGameFactory _gameFactory;
        public Menu(DataService dataService, IGameFactory gameFactory, Score score)
        {
            _dataService = dataService;
            _gameFactory = gameFactory;
            _score = score;
        }
        public void MainMenu()
        {
            Messages.ShowTitle();
            Messages.ShowMainMenu();

            try
            {
                var txtFileWords = _dataService.FileReader("words.txt");
                int userInput = Convert.ToInt32(Console.ReadLine());
                var game = _gameFactory.CreateGameWithDifficultyLvlAsInt(userInput, txtFileWords);
                var chancesLeft = game.StartGame();
                _score.SetChancesLeft(chancesLeft);
            }
            catch (Exception ex)
            {
                Messages.ShowException(ex.Message);
                MainMenu();
            }
        }

        public void GameOverMenu()
        {
            Messages.ShowTitle();
            Messages.ShowGameOverMenu();

            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out int resultUserInputAsInt))
            {
                switch (resultUserInputAsInt)
                {
                    case 1:
                        MainMenu();
                        break;

                    case 2:
                        Messages.ShowTitle();
                        _score.SaveForm();
                        _dataService.SaveScore(_score);
                        break;

                    case 3:
                        Messages.ShowTitle();
                        var bestScores = _dataService.JsonFileReader("10BestScores.json");
                        _score.ShowBestScores(bestScores);
                        Console.WriteLine("\nTO CONTINUE PRESS ANY BUTTON...");
                        Console.ReadLine();
                        break;

                    case 4:
                        return;

                    default:
                        break;
                }
            }
            else
            {
                Messages.ShowException("WRONG USER INPUT...");
            }
            GameOverMenu();
        }
    }
}
