using System;
using System.Collections.Generic;

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

    public class TennisGame4Context : IStateContext
    {
        public IScore Score { get; set; }

        public int Player1Score { get; private set; }
        public int Player2Score { get; private set; }

        public bool ScoresEqual() => Player1Score == Player2Score;

        public void PlayerScored(string player)
        {
            if (player == "player1")
                Player1Score++;
            else
                Player2Score++;
        }
    }

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

    public interface IScore
    {
        void WonPoint(string player);

        string GetScore();
    }

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

    public class NormalGame : IScore
    {
        private IStateContext context;

        private Dictionary<int, string> normalGameScores = new Dictionary<int, string>
        {
            {0, "Love" },
            {1, "Fifteen" },
            {2, "Thirty" },
            {3, "Forty" },
        };

        public NormalGame(IStateContext context) => this.context = context;

        public string GetScore()
        {
            var score = $"{normalGameScores[context.Player1Score]}-";
            return score += context.ScoresEqual() ? "All" : $"{normalGameScores[context.Player2Score]}";
        }

        public void WonPoint(string player)
        {
            context.PlayerScored(player);
            var algo = new GameWonAlgorithm(context.Player1Score, context.Player2Score);
            algo.WonInNormalGame(nameOfWinner => context.Score = new GameOver(nameOfWinner));
        }
    }

    public class GameWonAlgorithm
    {
        public GameWonAlgorithm(int score1, int score2)
        {
            Score1 = score1;
            Score2 = score2;
        }

        public int Score1 { get; }
        public int Score2 { get; }

        public void WonInNormalGame(Action<string> yes)
        {
            if (Score1 == 4 || Score2 == 4)
            {
                var playerDiff = Score1 - Score2;
                if (Math.Abs(playerDiff).Equals(2))
                {
                    yes?.Invoke(GetNameOfWinner(playerDiff));
                }
            }
        }

        private string GetNameOfWinner(int diff) => diff == 2 ? "player1" : "player2";

        public bool WonInExtraTime()
        {
            throw new NotImplementedException();
        }
    }

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
