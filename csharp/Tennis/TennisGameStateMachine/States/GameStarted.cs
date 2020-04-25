namespace Tennis.TennisGameStateMachine.States
{
    public class GameStarted : IScore
    {
        private readonly IStateContext _context;

        public GameStarted(IStateContext context)
        {
            _context = context;
            _context.Score = this;
        }

        public string GetScore()
        {
            _context.Score = new NormalGame(_context);
            return "Love-All";
        }

        public void WonPoint(string player)
        {
            _context.Score = new NormalGame(_context);
            _context.Score.WonPoint(player);
        }
    }
}
