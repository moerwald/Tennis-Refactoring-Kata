using System;

namespace Tennis.TennisGameStateMachine.Strategy
{
    public class WonInExtraTime : IGameWonAlgorithm
    {
        public WonInExtraTime(int score1, int score2)
        {
            Score1 = score1;
            Score2 = score2;
        }

        public int Score1 { get; }
        public int Score2 { get; }
        public void GameOver(Action<string> yes)
        {
            throw new NotImplementedException();
        }
    }
}
