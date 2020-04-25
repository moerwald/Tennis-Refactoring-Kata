namespace Tennis.TennisGameStateMachine.States
{
    public interface IScore
    {
        void WonPoint(string player);

        string GetScore();
    }
}
