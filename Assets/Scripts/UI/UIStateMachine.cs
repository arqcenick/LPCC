using System;
using UnityEngine;
using BaseStateMachine;
using CharacterCustomizer;
using UnityEngine.AddressableAssets;

namespace UI
{
    /// <summary>
    /// UI state machine handles the main transitions between the states, it can also listen to UIEvents.
    /// </summary>
    public class UIStateMachine : MonoBehaviour
    {
        private UIHeroSelector _heroSelector;
        private UIItemSelector _itemSelector;
        
        private StateMachine _stateMachine = new StateMachine();
        private HeroSelectionState _heroSelectionState;
        private ItemSelectionState _itemSelectionState;
        private Animator _uiAnimator;

        private void Awake()
        {

            var heroSelectors = FindObjectsOfType<UIHeroSelector>();
            Debug.Assert(heroSelectors.Length == 1, "There must be 1 hero selector per UI scene");
            _heroSelector = heroSelectors[0];
            
            var itemSelectors = FindObjectsOfType<UIItemSelector>();
            Debug.Assert(itemSelectors.Length == 1, "There must be 1 item selector per UI scene");
            _itemSelector = itemSelectors[0];
            
            var exitMenus = FindObjectsOfType<UIExitMenu>();
            Debug.Assert(exitMenus.Length == 1, "There must be 1 exit menu per UI scene");
            var exitMenu = exitMenus[0];
            
            
            _uiAnimator = GetComponent<Animator>();
            var overviewState = new OverviewState(_uiAnimator);
            _stateMachine.Add(overviewState);
            _heroSelectionState = new HeroSelectionState(_uiAnimator, _heroSelector);
            _itemSelectionState = new ItemSelectionState(_uiAnimator, _itemSelector);
            ExitMenuState exitMenuState = new ExitMenuState(_uiAnimator, exitMenu);
            _stateMachine.Add(exitMenuState);
            _stateMachine.Add(_heroSelectionState);
            _stateMachine.AddTransition(_heroSelectionState, _itemSelectionState, () => EventBuffer.IsTriggerSet<OnItemMenuSelected>());
            _stateMachine.AddTransition(_itemSelectionState, _heroSelectionState, () => EventBuffer.IsTriggerSet<OnHeroMenuSelected>() || Input.GetKeyDown(KeyCode.Escape));
            _stateMachine.AddTransition(_heroSelectionState, exitMenuState, () => Input.GetKeyDown(KeyCode.Escape));
            _stateMachine.AddTransition(exitMenuState, _heroSelectionState, () => Input.GetKeyDown(KeyCode.Escape));

            _stateMachine.Init();
            _stateMachine.SetState(_heroSelectionState);
            
            UIEventSingleton<OnItemTypeSelected, CharacterPart>.Instance.AddListener(ChangeBodyCam);
        }

        private void ChangeBodyCam(CharacterPart part)
        {
            if (part == CharacterPart.Helmet)
            {
                _uiAnimator.Play("FaceZoom");
            }
            else
            {
                _uiAnimator.Play("ItemSelection");
            }
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
