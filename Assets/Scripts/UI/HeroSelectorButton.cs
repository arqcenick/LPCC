using CharacterCustomizer;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace UI
{
    public class HeroSelectorButton : MonoBehaviour, IPointerClickHandler
    {
        [FormerlySerializedAs("_characterPart")] [SerializeField]
        private PlayerPartAsset.CharacterClass _characterClass;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            UIEventSingleton<OnCharacterSelected, PlayerPartAsset.CharacterClass>.Instance.Invoke(_characterClass);
        }        
    }
}