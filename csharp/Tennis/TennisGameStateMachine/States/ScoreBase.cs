namespace Tennis.TennisGameStateMachine.States
{
    public abstract class ScoreBase : IScore
    {
        public ScoreBase(IScoreContext scoreContext)
            => ScoreContext = scoreContext;

        protected IScoreContext ScoreContext { get; }

        protected int Player1Score => ScoreContext.Player1Score;
        protected int Player2Score => ScoreContext.Player2Score;

        public abstract string GetScore();
        public abstract void WonPoint(string player);
    }
}