using System;
using CharacterCustomizer;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    public class HeroSelectorButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private Image _selectionImage;
        
        [SerializeField]
        private Image _iconImage;

        [FormerlySerializedAs("_characterPart")] [SerializeField]
        private PlayerPartAsset.CharacterClass _characterClass;

        private CharacterDataAsset _reprenstedHero;
        private Toggle _toggle;

        private void Awake()
        {
            _toggle = GetComponent<Toggle>();
            _toggle.onValueChanged.AddListener(OnValueChanged);
            OnValueChanged(_toggle.isOn);

        }

        public void OnPointerClick(PointerEventData eventData)
        {
            UIEventSingleton<OnHeroSelected, CharacterDataAsset>.Instance.Invoke(_reprenstedHero);
            UIEventSingleton<OnButtonClicked>.Instance.Invoke();

        }

        public void SetHero(CharacterDataAsset characterDataAsset)
        {
            _reprenstedHero = characterDataAsset;
            _iconImage.sprite = _reprenstedHero.HeroIcon;
            
            if (GetComponent<Toggle>().isOn)
            {
                UIEventSingleton<OnHeroSelected, CharacterDataAsset>.Instance.Invoke(_reprenstedHero);
            }
        }
        
        private void OnValueChanged(bool val)
        {
            _selectionImage.DOFade(val ? 1 : 0 , 0.2f);
        }
    }
}