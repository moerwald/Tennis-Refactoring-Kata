namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;

        public TennisGame1()
        {
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                m_score1 += 1;
            else
                m_score2 += 1;
        }

        public string GetScore()
        {
            if (m_score1 == m_score2)
            {
                return PlayerScoresAreEven.Score(m_score1);
            }
            else if (m_score1 >= 4 || m_score2 >= 4)
            {
                return OnePlayerHasAdvantage.Score(m_score1, m_score2);
            }
            else
            {
                return PlayersHaveStandardScore.Score(m_score1, m_score2);
            }
        }
    }
}

