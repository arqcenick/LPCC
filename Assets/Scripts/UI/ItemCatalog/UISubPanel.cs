using System;
using CharacterCustomizer;
using DG.Tweening;
using UnityEngine;

namespace UI.ItemCatalog
{
    public class UISubPanel : MonoBehaviour
    {
        [SerializeField] private bool _isAlternative;
        private CanvasGroup _canvasGroup;
        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            UIEventSingleton<OnItemTypeSelected, CharacterPart>.Instance.AddListener(OnCharacterPartSelected);
        }

        private void OnCharacterPartSelected(CharacterPart characterPart)
        {
            bool isActive = !_isAlternative || UIAlternativeConverter.GetAlternativePart(characterPart) != CharacterPart.Invalid;
            gameObject.SetActive(isActive);
            if (isActive)
            {
                _canvasGroup.DOFade(1, 0.2f);
            }
            else
            {
                _canvasGroup.alpha = 0;
            }
        }
    }
}