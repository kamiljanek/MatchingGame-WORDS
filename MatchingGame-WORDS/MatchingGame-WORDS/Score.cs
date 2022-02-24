using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingGame_WORDS
{
    public class Score
    {
        public int chancesLeft;

        public string OwnerName = "empty";
        public string GuessingTime { get; set; }
        public DateTime Date = DateTime.Now;
        private void SetGuessingTime()
        {
            GuessingTime = (Game.TimerStop - Game.TimerStart).ToString("ss");
        }
        private void ShowCurrentScore()
        {
            SetGuessingTime();
            Console.WriteLine($"YOUR SCORE: |   Guessing time: {GuessingTime}s | ,   Chances left: {chancesLeft} | ,   Date: {Date}");
        }
        public void SaveForm()
        {
            ShowCurrentScore();
            Console.Write("\nENTER YOUR NICKNAME: ");
            string nickName = Console.ReadLine();
            ChangeOwnerName(nickName);
        }

        private void ChangeOwnerName(string newName)
        {
            OwnerName = newName;
        }
        public void ShowBestScores(List<Score> bestScores)
        {
            var sortedScores = SortByTime(bestScores);
            var tenBestScores = sortedScores.Take(10).ToList();
            for (int i = 0; i < tenBestScores.Count; i++)
            {
                Console.WriteLine($"{i+1}. {tenBestScores[i].OwnerName} | " +
                    $"Guess time: {tenBestScores[i].GuessingTime}s | Chances left: {tenBestScores[i].chancesLeft} | Date: {tenBestScores[i].Date}");
            }
        }
        private List<Score> SortByTime(List<Score> bestScores)
        {
            List<Score> sortedScores = bestScores.OrderBy(o => o.GuessingTime).ToList();
            return sortedScores;
        }
        public void SetChancesLeft(int chancesLeft)
        {
            this.chancesLeft = chancesLeft;
        }

    }
}
