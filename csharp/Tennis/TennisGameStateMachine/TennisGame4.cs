namespace Tennis.TennisGameStateMachine
{

    public class TennisGame4 : ITennisGame
    {
        private readonly TennisGame4Context tennisGame4Context;

        public TennisGame4(TennisGame4Context tennisGame4Context)
        {
            this.tennisGame4Context = tennisGame4Context;
        }

        public string GetScore()
        {
            return tennisGame4Context.Score.GetScore();
        }

        public void WonPoint(string playerName)
        {
            tennisGame4Context.Score.WonPoint(playerName);
        }
    }
}
