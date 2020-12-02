using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

namespace UI.ItemCatalog
{
    public class UIItemContainer : MonoBehaviour
    {
        public IReadOnlyList<UISkinElement> PartElements => _partElements;

        private List<UISkinElement> _partElements;
        private RectTransform _rectTransform;
        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            _partElements = GetComponentsInChildren<UISkinElement>().ToList();
            _rectTransform = (RectTransform) transform;

        }

        public void Hide()
        {
            _canvasGroup.DOFade(0, 0.25f);
            _rectTransform.DOAnchorPosX(_rectTransform.rect.width, 0.25f);
        }

        public void Show()
        {
            _rectTransform.DOKill();
            _rectTransform.anchoredPosition = new Vector2(-_rectTransform.rect.width, 0);
            _canvasGroup.DOFade(1, 0.25f);

            _rectTransform.DOAnchorPosX(0, 0.25f);
        }
    }
}