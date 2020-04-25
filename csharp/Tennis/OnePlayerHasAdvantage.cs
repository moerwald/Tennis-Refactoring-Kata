using System.Collections.Generic;

namespace Tennis
{
    internal static class OnePlayerHasAdvantage
    {
        public static string Score(int p1Score, int p2Score) => _AdvantageOrWin[p1Score - p2Score];

        private static IReadOnlyDictionary<int, string> _AdvantageOrWin =
            new Dictionary<int, string>
            {
                {1,  "Advantage player1"},
                {2,  "Win for player1"},
                {3,  "Win for player1" },
                {4,  "Win for player1" },
                {-1, "Advantage player2"},
                {-2, "Win for player2" },
                {-3, "Win for player2" },
                {-4, "Win for player2" },
            };
    }
}

