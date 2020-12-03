using System;
using UnityEngine;
using BaseStateMachine;
using UnityEngine.AddressableAssets;

namespace UI
{

    public class UIStateMachine : MonoBehaviour
    {
        [SerializeField] 
        private UIHeroSelector _heroSelector;
        
        private StateMachine _stateMachine = new StateMachine();
        private void Awake()
        {

            Animator uiAnimator = GetComponent<Animator>();
            var overviewState = new OverviewState(uiAnimator);
            _stateMachine.Add(overviewState);
            var heroSelectionState = new HeroSelectionState(uiAnimator, _heroSelector);
            _stateMachine.Add(heroSelectionState);
            _stateMachine.AddTransition(heroSelectionState, overviewState, () => EventBuffer.IsTriggerSet<OnOverviewMenuSelected>());
            _stateMachine.AddTransition(overviewState, heroSelectionState, () => EventBuffer.IsTriggerSet<OnHeroMenuSelected>());
            _stateMachine.Init();
            _stateMachine.SetState(overviewState);

        }

        private void Update()
        {
            _stateMachine.Tick();
            EventBuffer.Clear();
        }
    }
}
