using System.Collections.Generic;

namespace Tennis
{
    internal static class PlayerScoresAreEven
    {
        public static string Score(int score) => _PlayerScoreEven[score];

        private static IReadOnlyDictionary<int, string> _PlayerScoreEven =
            new Dictionary<int, string>
            {
                {0,  "Love-All"},
                {1,  "Fifteen-All"},
                {2,  "Thirty-All"},
                {3,  "Deuce" },
                {4,  "Deuce" },
            };

    }
}

