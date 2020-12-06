using System.Collections;
using BaseStateMachine;
using NUnit.Framework;
using UI;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ui_state_machine_tests
    {
        [UnityTest]
        public IEnumerator state_machine_transits_correctly()
        {
            StateMachine stateMachine = new StateMachine();
            Animator uiAnimator = null;
            var overviewState = new OverviewState(uiAnimator);
            stateMachine.Add(overviewState);
            var heroSelectionState = new HeroSelectionState(uiAnimator);
            stateMachine.Add(heroSelectionState);
            stateMachine.AddTransition(heroSelectionState, overviewState, () => EventBuffer.IsTriggerSet<OnOverviewMenuSelected>());
            stateMachine.SetState(heroSelectionState);
            
            Debug.Assert(stateMachine.CurrentState == heroSelectionState);
            
            stateMachine.Tick();

            yield return null;
            
            Debug.Assert(stateMachine.CurrentState == heroSelectionState);

            yield return null;

            UIEventSingleton<OnOverviewMenuSelected>.Instance.Invoke();
            
            yield return null;

            stateMachine.Tick();
            
            Debug.Assert(stateMachine.CurrentState == overviewState);
        }

        [UnityTest]
        public IEnumerator state_machine_triggers_reset_correctly()
        {
            StateMachine stateMachine = new StateMachine();
            Animator uiAnimator = null;
            var overviewState = new OverviewState(uiAnimator);
            stateMachine.Add(overviewState);
            var heroSelectionState = new HeroSelectionState(uiAnimator, null);
            stateMachine.Add(heroSelectionState);
            var itemSelectionState = new ItemSelectionState(uiAnimator, null);
            stateMachine.Add(itemSelectionState);
            stateMachine.AddTransition(overviewState, heroSelectionState,
                () => EventBuffer.IsTriggerSet<OnHeroMenuSelected>());
            stateMachine.AddTransition(heroSelectionState, overviewState,
                () => EventBuffer.IsTriggerSet<OnOverviewMenuSelected>());
            stateMachine.Init();
            
            stateMachine.SetState(heroSelectionState);
            Debug.Assert(stateMachine.CurrentState == heroSelectionState);
            
            stateMachine.Tick();

            yield return null;
            
            Debug.Assert(stateMachine.CurrentState == heroSelectionState);

            yield return null;

            UIEventSingleton<OnOverviewMenuSelected>.Instance.Invoke();
            
            yield return null;
            stateMachine.Tick();
            Debug.Assert(stateMachine.CurrentState == overviewState);
            
            UIEventSingleton<OnHeroMenuSelected>.Instance.Invoke();

            for (int i = 0; i < 2; i++)
            {
                yield return null;
                stateMachine.Tick();
                Debug.Assert(stateMachine.CurrentState == heroSelectionState);
            }
            
        }
        

        [UnityTest]
        public IEnumerator state_machine_transits_correctly_to_multiple_states()
        {
            StateMachine stateMachine = new StateMachine();
            Animator uiAnimator = null;
            var overviewState = new OverviewState(uiAnimator);
            stateMachine.Add(overviewState);
            var heroSelectionState = new HeroSelectionState(uiAnimator, null);
            stateMachine.Add(heroSelectionState);
            var itemSelectionState = new ItemSelectionState(uiAnimator, null);
            stateMachine.Add(itemSelectionState);
            stateMachine.AddTransition(overviewState, heroSelectionState, () => EventBuffer.IsTriggerSet<OnHeroMenuSelected>());
            stateMachine.AddTransition(heroSelectionState, overviewState, () => EventBuffer.IsTriggerSet<OnOverviewMenuSelected>());
            stateMachine.AddTransition(overviewState, itemSelectionState, () => EventBuffer.IsTriggerSet<OnItemMenuSelected>());

            stateMachine.Init();
            
            stateMachine.SetState(heroSelectionState);
            
            
            Debug.Assert(stateMachine.CurrentState == heroSelectionState);
            
            stateMachine.Tick();

            yield return null;
            
            Debug.Assert(stateMachine.CurrentState == heroSelectionState);

            yield return null;

            UIEventSingleton<OnOverviewMenuSelected>.Instance.Invoke();
            
            yield return null;
            stateMachine.Tick();
            Debug.Assert(stateMachine.CurrentState == overviewState);
            
            
            UIEventSingleton<OnItemMenuSelected>.Instance.Invoke();

            yield return null;
            stateMachine.Tick();
            Debug.Assert(stateMachine.CurrentState == itemSelectionState);
            
            UIEventSingleton<OnHeroMenuSelected>.Instance.Invoke();

            yield return null;
            stateMachine.Tick();
            Debug.Assert(stateMachine.CurrentState == itemSelectionState);
        }
    }
}