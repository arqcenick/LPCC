using UnityEngine;

namespace BaseStateMachine
{
    public abstract class  State
    {
        protected Animator UIStateAnimator;
        
        public State(Animator animator)
        {
            UIStateAnimator = animator;
        }
        public abstract void OnEnter();
        public abstract void OnExit();
        public abstract void Tick();
    }
}