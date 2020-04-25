using Tennis.TennisGameStateMachine.States;

namespace Tennis.TennisGameStateMachine
{
    public class ScoreContextForTwoPlayers : IScoreContext
    {
        public IScore GameState { get; set; }
        public int Player1Score { get; private set; }
        public int Player2Score { get; private set; }

        public void PlayerScored(string player)
        {
            if (player == PlayerNames.Player1)
                Player1Score++;
            else
                Player2Score++;
        }
    }
}
