using System;

namespace Tennis.TennisGameStateMachine.Strategy
{
    public interface IGameWon
    {
        void Yes(Action<string> yes);
    }
}