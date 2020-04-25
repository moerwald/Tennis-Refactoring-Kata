namespace Tennis.TennisGameStateMachine.States
{
    public sealed class GameStarted : ScoreBase
    {
        public GameStarted(IScoreContext context)
            :base(context)
            => ScoreContext.Score = this;

        public override string GetScore() => "Love-All";

        public override void WonPoint(string player)
        {
            ScoreContext.Score = new NormalGame(ScoreContext);
            ScoreContext.Score.WonPoint(player);
        }
    }
}
