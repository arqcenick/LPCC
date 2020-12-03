using System;
using System.Collections.Generic;

namespace BaseStateMachine
{
    //State machine code is from a former project.
    public class StateMachine
    {
        public State CurrentState => _currentState;
        private Dictionary<State, List<StateTransition>> _transitions = new Dictionary<State, List<StateTransition>>();
        private List<State> _states = new List<State>();
        private State _currentState;

        public void Add(State state)
        {
            _states.Add(state);
        }

        public void SetState(State state)
        {
            if (_currentState == state)
            {
                return;
            }
            _currentState?.OnExit();
            _currentState = state;
            _currentState.OnEnter();
        }

        public void AddTransition(State from, State to, Func<bool> condition)
        {
            if (!_transitions.ContainsKey(from))
            {
                _transitions[from] = new List<StateTransition>();
            }

            var uiStateTransition = new StateTransition(@from, to, condition);
            _transitions[from].Add(uiStateTransition);
        }

        public void Tick()
        {
            var transition = CheckForTransition();
            if (transition != null)
            {
                SetState(transition.To);
            }
            _currentState.Tick();
        }

        private StateTransition CheckForTransition()
        {
            if (_transitions.ContainsKey(_currentState))
            {
                foreach (var transition in _transitions[_currentState])
                {
                    if (transition.Condition())
                    {
                        return transition;
                    }
                }
            }
            return null;
        }

        public void Init()
        {
            foreach (var transition in _transitions)
            {
                foreach (var stateTransition in transition.Value)
                {
                    stateTransition.Condition();
                }
            }
        }
    }
}