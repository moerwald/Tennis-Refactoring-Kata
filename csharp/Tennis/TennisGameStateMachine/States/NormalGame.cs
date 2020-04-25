using System.Collections.Generic;
using Tennis.TennisGameStateMachine.Strategy;

namespace Tennis.TennisGameStateMachine.States
{
    public class NormalGame : IScore
    {
        private IStateContext _context;
        private NormalGameWon _gameOver;
        private GameIsDeuce _gameIsDeuce;
        private Dictionary<int, string> normalGameScores = new Dictionary<int, string>
        {
            {0, "Love" },
            {1, "Fifteen" },
            {2, "Thirty" },
            {3, "Forty" },
        };

        public NormalGame(IStateContext context)
        {
            this._context = context;
            this._gameOver = new NormalGameWon(context);
            this._gameIsDeuce = new GameIsDeuce(context);
        }

        public string GetScore()
        {
            var score = $"{normalGameScores[_context.Player1Score]}-";
            return score += _context.ScoresEqual() ? "All" : $"{normalGameScores[_context.Player2Score]}";
        }

        public void WonPoint(string player)
        {
            _context.PlayerScored(player);
            _gameOver.Yes(nameOfWinner => _context.Score = new GameOver(nameOfWinner));
            _gameIsDeuce.Yes(() => _context.Score = new Deuce(_context));
        }
    }
}
