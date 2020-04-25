using System;

namespace Tennis.TennisGameStateMachine.Strategy
{
    public sealed class GameWonInExtraTime : IGameWon
    {
        private readonly IScoreContext _context;
        private int Player1Score => _context.Player1Score;
        private int Player2Score => _context.Player2Score;

        public GameWonInExtraTime(IScoreContext context) => _context = context;

        public void Yes(Action<string> yes)
        {
            var diff = Player1Score - Player2Score;
            if (PlayerLeadsWithTwoPoints(diff))
            {
                yes?.Invoke(WinnerPlayerName(diff));
            }
        }

        private static string WinnerPlayerName(int diff)
            => diff > 0 ? PlayerNames.Player1 : PlayerNames.Player2;

        private static bool PlayerLeadsWithTwoPoints(int diff) => Math.Abs(diff) == 2;
    }
}
