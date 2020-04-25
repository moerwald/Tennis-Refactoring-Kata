using System;

namespace Tennis.TennisGameStateMachine.Strategy
{
    internal class GameIsDeuce : IChangeGamePhase

    {
        private readonly IScoreContext _context;

        public GameIsDeuce(IScoreContext context) => _context = context;

        private int Player1Score => _context.Player1Score;
        private int Player2Score => _context.Player2Score;

        private const int Thirty = 3;
        private const int Forty = 4;

        public void Yes(Action yes)
        {
            if (ThirtyBoth() || FortyBoth())
                yes?.Invoke();
        }

        private bool FortyBoth() => Player1Score == Forty && Player2Score == Forty;

        private bool ThirtyBoth() => Player1Score == Thirty && Player2Score == Thirty;
    }
}
