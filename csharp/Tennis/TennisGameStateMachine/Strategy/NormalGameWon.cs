using System;

namespace Tennis.TennisGameStateMachine.Strategy
{
    public class NormalGameWon : IGameWonAlgorithm
    {
        public NormalGameWon(IStateContext context)
        {
            Context = context;
        }

        public int Score1 { get => Context.Player1Score; }
        public int Score2 { get => Context.Player2Score; }

        public IStateContext Context { get; }

        private const int ScoreDiffToWin = 2;
        private const int Forty = 4;

        public void Yes(Action<string> yes)
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
