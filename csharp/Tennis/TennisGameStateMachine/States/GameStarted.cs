namespace Tennis.TennisGameStateMachine.States
{
    public sealed class GameStarted : ScoreBase
    {
        public GameStarted(IScoreContext context)
            :base(context)
            => ScoreContext.GameState = this;

        public override string GetScore() => "Love-All";

        public override void WonPoint(string player)
        {
            ScoreContext.GameState = new NormalGame(ScoreContext);
            ScoreContext.GameState.WonPoint(player);
        }
    }
}
