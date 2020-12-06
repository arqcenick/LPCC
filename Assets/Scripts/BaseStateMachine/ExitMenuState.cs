using DG.Tweening;
using UI;
using UnityEngine;

namespace BaseStateMachine
{
    public class ExitMenuState : State
    {
        private readonly UIExitMenu _exitMenu;
        private RectTransform _rectTransform;
        private Vector2 _originalPosition;
        public ExitMenuState(Animator animator, UIExitMenu exitMenu) : base(animator)
        {
            _exitMenu = exitMenu;
            _rectTransform = _exitMenu?.transform as RectTransform;
            _originalPosition = _rectTransform?.position ?? Vector2.zero;
        }

        public override void OnEnter()
        {
            _rectTransform?.DOMove(_originalPosition, 0.25f);
            _exitMenu?.GetComponent<CanvasGroup>().DOFade(1, 0.4f);
        }

        public override void OnExit()
        {
            _rectTransform?.DOMoveY(_originalPosition.y + _rectTransform.rect.height * 3, 0.25f);
            _exitMenu?.GetComponent<CanvasGroup>().DOFade(0, 0.4f);
        }

        public override void Tick()
        {
        }
    }
}