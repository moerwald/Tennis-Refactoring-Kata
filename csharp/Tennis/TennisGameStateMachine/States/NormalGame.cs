using System.Collections.Generic;
using Tennis.TennisGameStateMachine.Strategy;

namespace Tennis.TennisGameStateMachine.States
{
    public sealed class NormalGame : ScoreBase
    {
        private readonly GameWonInStandardMode _gameOver;
        private readonly GameIsDeuce _gameIsDeuce;
        private readonly IReadOnlyDictionary<int, string> normalGameScores = new Dictionary<int, string>
        {
            {0, "Love" },
            {1, "Fifteen" },
            {2, "Thirty" },
            {3, "Forty" },
        };

        public NormalGame(IScoreContext context)
            :base(context)
        {
            _gameOver = new GameWonInStandardMode(context);
            _gameIsDeuce = new GameIsDeuce(context);
        }

        public override string GetScore() =>
            string.Format("{0}-{1}",
                          normalGameScores[ScoreContext.Player1Score],
                          Player1Score == Player2Score ? "All" : $"{normalGameScores[ScoreContext.Player2Score]}");

        public override void WonPoint(string player)
        {
            ScoreContext.PlayerScored(player);
            _gameOver.Yes(nameOfWinner => ScoreContext.GameState = new GameOver(nameOfWinner));
            _gameIsDeuce.Yes(() => ScoreContext.GameState = new Deuce(ScoreContext));
        }
    }
}
