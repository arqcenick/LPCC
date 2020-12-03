using UnityEngine;

namespace BaseStateMachine
{
    public class OverviewState : State
    {
        public OverviewState(Animator animator) : base(animator)
        {
        }
        public override void OnEnter()
        {
            UIStateAnimator?.Play("Overview");

        }

        public override void OnExit()
        {
        }

        public override void Tick()
        {
        }



    }
}