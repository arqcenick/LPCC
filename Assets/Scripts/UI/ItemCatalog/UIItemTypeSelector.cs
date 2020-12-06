using System;
using CharacterCustomizer;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.ItemCatalog
{
    public class UIItemTypeSelector : MonoBehaviour, IPointerClickHandler
    {
        public CharacterPart CharacterPart => _characterPart;
        
        [SerializeField]
        private CharacterPart _characterPart;
        

        public void EmulateClick()
        {
            GetComponent<Toggle>().isOn = true;
            OnPointerClick(null);
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            UIEventSingleton<OnItemTypeSelected, CharacterPart>.Instance.Invoke(_characterPart);
        }
    }
}
