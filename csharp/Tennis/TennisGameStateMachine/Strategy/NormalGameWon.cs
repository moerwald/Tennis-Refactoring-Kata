using System;

namespace Tennis.TennisGameStateMachine.Strategy
{
    public class NormalGameWon : IGameWonAlgorithm
    {
        public NormalGameWon(int score1, int score2)
        {
            Score1 = score1;
            Score2 = score2;
        }

        public int Score1 { get; }
        public int Score2 { get; }

        private const int ScoreDiffToWin = 2;
        private const int Forty = 4;

        public void GameOver(Action<string> yes)
        {
            var playerDiff = Score1 - Score2;
            if (OnePlayerReachedForty() && ScoreDiffIsMoreThanTwo(playerDiff))
            {
                yes?.Invoke(GetNameOfWinner(playerDiff));
            }
        }

        private bool ScoreDiffIsMoreThanTwo(int playerDiff) => Math.Abs(playerDiff) >= ScoreDiffToWin;

        private bool OnePlayerReachedForty() => Score1 == Forty || Score2 == Forty;

        private string GetNameOfWinner(int diff) => diff >= ScoreDiffToWin ? "player1" : "player2";
    }
}
