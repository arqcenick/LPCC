using System;

namespace BaseStateMachine
{
    public class StateTransition
    {
        public readonly State From;
        public readonly State To;
        public readonly Func<bool> Condition;

        public StateTransition(State @from, State to, Func<bool> condition)
        {
            From = @from;
            To = to;
            Condition = condition;
        }
    }
}