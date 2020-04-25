namespace Tennis.TennisGameStateMachine
{

    public class TennisGame4 : ITennisGame
    {
        private readonly ScoreContextForTwoPlayers _tennisGame4Context;

        public TennisGame4(ScoreContextForTwoPlayers tennisGame4Context)
            => _tennisGame4Context = tennisGame4Context;

        public string GetScore() => _tennisGame4Context.GameState.GetScore();

        public void WonPoint(string playerName) => _tennisGame4Context.GameState.WonPoint(playerName);
    }
}
