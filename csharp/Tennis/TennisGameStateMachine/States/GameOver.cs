namespace Tennis.TennisGameStateMachine.States
{
    public sealed class GameOver : IScore
    {
        private readonly string _playerName;

        public GameOver(string playerName)
            => _playerName = playerName;

        public string GetScore() => $"Win for {_playerName}";

        public void WonPoint(string player) { }
    }
}
