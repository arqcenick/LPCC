using DG.Tweening;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace BaseStateMachine
{
    public class HeroSelectionState : State
    {
        private readonly UIHeroSelector _heroSelector;
        private RectTransform _rectTransform;
        private Vector2 _originalPosition;

        public HeroSelectionState(Animator animator, UIHeroSelector heroSelector=null) : base(animator)
        {
            _heroSelector = heroSelector;
            _rectTransform = _heroSelector?.transform as RectTransform;
            _originalPosition = _rectTransform?.position ?? Vector2.zero;

        }
        public override void OnEnter()
        {
            UIStateAnimator?.Play("HeroSelection");
            _rectTransform?.DOMove(_originalPosition, 0.25f);
            _heroSelector?.GetComponent<CanvasGroup>().DOFade(1, 0.4f);
        }

        public override void OnExit()
        {
            _rectTransform?.DOMoveX(_originalPosition.x - _rectTransform.rect.width * 2, 0.25f);
            _heroSelector?.GetComponent<CanvasGroup>().DOFade(0, 0.4f);

        }

        public override void Tick()
        {
            
        }
    }
}