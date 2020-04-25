using System.Collections.Generic;
using Tennis.TennisGameStateMachine.Strategy;

namespace Tennis.TennisGameStateMachine.States
{
    public class NormalGame : IScore
    {
        private IStateContext context;

        private Dictionary<int, string> normalGameScores = new Dictionary<int, string>
        {
            {0, "Love" },
            {1, "Fifteen" },
            {2, "Thirty" },
            {3, "Forty" },
        };

        public NormalGame(IStateContext context) => this.context = context;

        public string GetScore()
        {
            var score = $"{normalGameScores[context.Player1Score]}-";
            return score += context.ScoresEqual() ? "All" : $"{normalGameScores[context.Player2Score]}";
        }

        public void WonPoint(string player)
        {
            context.PlayerScored(player);
            var algo = new NormalGameWon(context.Player1Score, context.Player2Score);
            algo.GameOver(nameOfWinner => context.Score = new GameOver(nameOfWinner));
        }
    }
}
