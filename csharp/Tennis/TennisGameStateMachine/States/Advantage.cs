﻿using Tennis.TennisGameStateMachine.Strategy;

namespace Tennis.TennisGameStateMachine.States
{
    public sealed class Advantage : ScoreBase
    {
        private readonly GameWonInExtraTime _gameOver;
        private readonly GameIsDeuce _gameIsDeuce;

        public Advantage(IScoreContext context)
            : base(context)
        {
            _gameOver = new GameWonInExtraTime(ScoreContext);
            _gameIsDeuce = new GameIsDeuce(ScoreContext);
        }

        public override string GetScore()
            => string.Format("Advantage {0}",
                        Player1Score - Player2Score > 0
                        ? PlayerNames.Player1
                        : PlayerNames.Player2);

        public override void WonPoint(string player)
        {
            ScoreContext.PlayerScored(player);
            _gameOver.Yes(winner => ScoreContext.GameState = new GameOver(winner));
            _gameIsDeuce.Yes(() => ScoreContext.GameState = new Deuce(ScoreContext));
        }
    }
}