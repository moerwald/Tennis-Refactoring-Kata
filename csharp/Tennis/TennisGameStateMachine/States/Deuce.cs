using System.Runtime.InteropServices.WindowsRuntime;

namespace Tennis.TennisGameStateMachine.States
{
    public sealed class Deuce : ScoreBase
    {
        public Deuce(IScoreContext context)
            :base (context)
        {
        }

        public override string GetScore() => "Deuce";

        public override void WonPoint(string player)
        {
            ScoreContext.PlayerScored(player);
            if (Player1Score != Player2Score)
                ScoreContext.GameState = new Advantage(ScoreContext);
        }
    }
}
