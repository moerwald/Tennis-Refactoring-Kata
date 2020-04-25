using Tennis.TennisGameStateMachine.States;

namespace Tennis.TennisGameStateMachine
{
    public interface IStateContext
    {
        IScore Score { get; set; }

        void PlayerScored(string player);

        bool ScoresEqual();
        int Player1Score { get; }
        int Player2Score { get; }
    }
}
