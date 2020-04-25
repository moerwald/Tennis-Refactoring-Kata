using Tennis.TennisGameStateMachine.Strategy;

namespace Tennis.TennisGameStateMachine.States
{
    public sealed class Advantage : ScoreBase
    {
        private readonly WonInExtraTime _gameOver;
        private readonly GameIsDeuce _gameIsDeuce;

        public Advantage(IScoreContext context)
            :base (context)
        {
            _gameOver = new WonInExtraTime(ScoreContext);
            _gameIsDeuce = new GameIsDeuce(ScoreContext);
        }

        public override string GetScore() 
            => Player1Score - Player2Score > 0 
            ? $"Advantage {PlayerNames.Player1}" 
            : $"Advantage {PlayerNames.Player2}";

        public override void WonPoint(string player)
        {
            ScoreContext.PlayerScored(player);
            _gameOver.Yes(winner => ScoreContext.Score = new GameOver(winner));
            _gameIsDeuce.Yes(() => ScoreContext.Score = new Deuce(ScoreContext));
        }
    }
}