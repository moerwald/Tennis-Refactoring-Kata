using System;

namespace Tennis.TennisGameStateMachine.Strategy
{
    public sealed class GameWonInStandardMode : IGameWon
    {
        public GameWonInStandardMode(IScoreContext context) => _context = context;

        private int Score1 => _context.Player1Score;
        private int Score2 => _context.Player2Score;

        private readonly IScoreContext _context;

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

        private string GetNameOfWinner(int diff) => diff >= ScoreDiffToWin
            ? PlayerNames.Player1
            : PlayerNames.Player2;
    }
}
