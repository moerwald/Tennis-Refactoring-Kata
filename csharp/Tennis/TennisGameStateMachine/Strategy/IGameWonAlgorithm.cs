﻿using System;

namespace Tennis.TennisGameStateMachine.Strategy
{
    public interface IGameWonAlgorithm
    {
        void Yes(Action<string> yes);
    }
}