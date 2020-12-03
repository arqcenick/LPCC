using UnityEngine;

namespace BaseStateMachine
{
    public class ItemSelectionState : State
    {
        
        public ItemSelectionState(Animator animator) : base(animator)
        {
        }
        public override void OnEnter()
        {
            UIStateAnimator?.Play("ItemSelection");
        }

        public override void OnExit()
        {
        }

        public override void Tick()
        {
            
        }
    }
}