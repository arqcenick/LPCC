using CharacterCustomizer;
using DG.Tweening;
using UI.ItemCatalog;
using UnityEngine;

namespace BaseStateMachine
{
    public class ItemSelectionState : State
    {
        private readonly UIItemSelector _heroSelector;
        private RectTransform _rectTransform;
        private Vector2 _originalPosition;
        
        public ItemSelectionState(Animator animator, UIItemSelector itemSelector) : base(animator)
        {
            _heroSelector = itemSelector;
            _rectTransform = _heroSelector?.transform as RectTransform;
            _originalPosition = _rectTransform?.position ?? Vector2.zero;
        }
        public override void OnEnter()
        {
            UIStateAnimator?.Play("ItemSelection");
            _rectTransform?.DOMove(_originalPosition, 0.25f);
            _heroSelector?.GetComponent<CanvasGroup>().DOFade(1, 0.4f);
            PlayerCharacterController.Instance.SaveCharacterData();
            UIEventSingleton<ForceItemTypeSelected, CharacterPart>.Instance.Invoke(CharacterPart.Helmet);

        }

        public override void OnExit()
        {
            _rectTransform?.DOMoveX(_originalPosition.x + _rectTransform.rect.width * 2, 0.25f);
            _heroSelector?.GetComponent<CanvasGroup>().DOFade(0, 0.4f);
        }

        public override void Tick()
        {
            
        }
    }
}