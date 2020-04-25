using Tennis.TennisGameStateMachine.Strategy;

namespace Tennis.TennisGameStateMachine.States
{
    internal class Advantage : IScore
    {
        private IStateContext _context;
        private WonInExtraTime _gameOver;
        private GameIsDeuce _gameIsDeuce;

        public Advantage(IStateContext context)
        {
            _context = context;
            _gameOver = new WonInExtraTime(_context);
            _gameIsDeuce = new GameIsDeuce(_context);
        }

        public string GetScore() => _context.ScoreDiff() > 0 ? "Advantage player1" : "Advantage player2";

        public void WonPoint(string player)
        {
            _context.PlayerScored(player);
            _gameOver.Yes(winner => _context.Score = new GameOver(winner));
            _gameIsDeuce.Yes(() => _context.Score = new Deuce(_context));
        }
    }
}