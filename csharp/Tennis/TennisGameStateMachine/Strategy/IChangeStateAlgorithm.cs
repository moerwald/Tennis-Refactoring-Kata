using System;

namespace Tennis.TennisGameStateMachine.Strategy
{
    public interface IChangeStateAlgorithm
    {
        void Yes(Action yes);
    }
}