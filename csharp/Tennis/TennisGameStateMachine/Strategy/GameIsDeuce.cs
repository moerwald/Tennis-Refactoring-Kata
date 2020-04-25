using System;

namespace Tennis.TennisGameStateMachine.Strategy
{
    internal class GameIsDeuce : IChangeStateAlgorithm

    {
        private readonly IStateContext context;

        public GameIsDeuce(IStateContext context) => this.context = context;

        private int Player1Score => context.Player1Score;
        private int Player2Score => context.Player2Score;

        public void Yes(Action yes)
        {
            if ((Player1Score == 3 && Player2Score == 3) || 
                (Player1Score == 4 && Player2Score == 4)) 
                yes?.Invoke();
        }
    }
}
