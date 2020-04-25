using Tennis.TennisGameStateMachine.States;

namespace Tennis.TennisGameStateMachine
{
    public interface IScoreContext
    {
        IScore GameState { get; set; }
        void PlayerScored(string player);
        int Player1Score { get; }
        int Player2Score { get; }
    }
}
