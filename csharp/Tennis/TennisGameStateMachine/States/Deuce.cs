using System.Runtime.InteropServices.WindowsRuntime;

namespace Tennis.TennisGameStateMachine.States
{
    public class Deuce : IScore
    {
        private IStateContext _context;

        public Deuce(IStateContext context) => _context = context;
        public string GetScore() => "Deuce";

        public void WonPoint(string player)
        {
            _context.PlayerScored(player);
            if (_context.ScoresEqual() == false)
                _context.Score = new Advantage(_context);
        }
    }
}
