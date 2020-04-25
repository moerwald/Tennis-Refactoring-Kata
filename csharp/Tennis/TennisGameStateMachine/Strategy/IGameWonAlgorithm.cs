using System;

namespace Tennis.TennisGameStateMachine.Strategy
{
    public interface IGameWonAlgorithm
    {
        void GameOver(Action<string> yes);
    }
}