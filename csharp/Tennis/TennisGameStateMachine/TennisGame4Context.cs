using Tennis.TennisGameStateMachine.States;

namespace Tennis.TennisGameStateMachine
{
    public class TennisGame4Context : IStateContext
    {
        public IScore Score { get; set; }

        public int Player1Score { get; private set; }
        public int Player2Score { get; private set; }

        public bool ScoresEqual() => Player1Score == Player2Score;

        public void PlayerScored(string player)
        {
            if (player == "player1")
                Player1Score++;
            else
                Player2Score++;
        }
    }
}
