using System;

namespace Tennis.TennisGameStateMachine.Strategy
{
    public interface IChangeGamePhase
    {
        void Yes(Action yes);
    }
}