using System;
using UnityEngine;
using BaseStateMachine;
using CharacterCustomizer;
using UnityEngine.AddressableAssets;

namespace UI
{
    public class UIStateMachine : MonoBehaviour
    {
        private UIHeroSelector _heroSelector;
        private UIItemSelector _itemSelector;
        
        private StateMachine _stateMachine = new StateMachine();
        private HeroSelectionState _heroSelectionState;
        private ItemSelectionState _itemSelectionState;

        private void Awake()
        {

            var heroSelectors = FindObjectsOfType<UIHeroSelector>();
            Debug.Assert(heroSelectors.Length == 1, "There must be 1 hero selector per UI scene");
            _heroSelector = heroSelectors[0];
            
            var itemSelectors = FindObjectsOfType<UIItemSelector>();
            Debug.Assert(itemSelectors.Length == 1, "There must be 1 item selecter per UI scene");
            _itemSelector = itemSelectors[0];
            
            Animator uiAnimator = GetComponent<Animator>();
            var overviewState = new OverviewState(uiAnimator);
            _stateMachine.Add(overviewState);
            _heroSelectionState = new HeroSelectionState(uiAnimator, _heroSelector);
            _itemSelectionState = new ItemSelectionState(uiAnimator, _itemSelector);
            
            _stateMachine.Add(_heroSelectionState);
            _stateMachine.AddTransition(_heroSelectionState, _itemSelectionState, () => EventBuffer.IsTriggerSet<OnItemMenuSelected>());
            _stateMachine.AddTransition(_itemSelectionState, _heroSelectionState, () => EventBuffer.IsTriggerSet<OnHeroMenuSelected>());
            _stateMachine.Init();
            _stateMachine.SetState(_heroSelectionState);

        }

        public void DoTransitToHeroSelectionConfirmed()
        {
            PlayerCharacterController.Instance.ConfirmCharacterChanges();
            _stateMachine.SetState(_heroSelectionState);
        }
        
        
        public void DoTransitToHeroSelectionCancelled()
        {
            PlayerCharacterController.Instance.RevertCharacterChanges();
            _stateMachine.SetState(_heroSelectionState);
        }


        public void DoTransitToItemSelection()
        {
            PlayerCharacterController.Instance.SaveCharacterData();
                UIEventSingleton<OnItemTypeSelected, CharacterPart>.Instance.Invoke(CharacterPart.Helmet);
            _stateMachine.SetState(_itemSelectionState);
        }
        
        private void Update()
        {
            _stateMachine.Tick();
            EventBuffer.Clear();
        }
    }
}
