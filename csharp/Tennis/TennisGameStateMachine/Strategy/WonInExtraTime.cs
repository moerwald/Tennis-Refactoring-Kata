using System;

namespace Tennis.TennisGameStateMachine.Strategy
{
    public class WonInExtraTime : IGameWonAlgorithm
    {
        private IStateContext _context;

        public WonInExtraTime(IStateContext context) => _context = context;

        public int Score1 => _context.Player1Score;
        public int Score2 => _context.Player2Score;

        public void Yes(Action<string> yes)
        {
            var x = Score2;
            var diff = _context.ScoreDiff();
            if (Math.Abs(diff) == 2)
            {
                yes?.Invoke(diff > 0 ? "player1" : "player2");
            }
        }
    }
}
