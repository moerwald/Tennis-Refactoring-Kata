namespace Tennis.TennisGameStateMachine.States
{
    public class GameOver : IScore
    {
        private string playerName;

        public GameOver(string playerName)
        {
            this.playerName = playerName;
        }

        public string GetScore() => $"Win for {playerName}";

        public void WonPoint(string player) { }
    }
}
