using System.Collections.Generic;

namespace Tennis
{
    internal static class PlayersHaveStandardScore
    {
        public static string Score (int p1Score, int p2Score)
            => $"{_ScoreValueToString[p1Score]}-{_ScoreValueToString[p2Score]}";

        private static readonly IReadOnlyDictionary<int, string> _ScoreValueToString = new Dictionary<int, string>
        {
            {0, "Love" },
            {1, "Fifteen" },
            {2, "Thirty" },
            {3, "Forty" },
        };
    }
}

