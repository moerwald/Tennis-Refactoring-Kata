using Tennis.TennisGameStateMachine.States;

namespace Tennis.TennisGameStateMachine
{
    public interface IScoreContext
    {
        IScore Score { get; set; }
        void PlayerScored(string player);
        int Player1Score { get; }
        int Player2Score { get; }
    }
}
