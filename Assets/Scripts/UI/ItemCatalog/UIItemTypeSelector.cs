using System;
using CharacterCustomizer;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace UI.ItemCatalog
{

    public class UIItemTypeSelector : MonoBehaviour, IPointerClickHandler
    {

        [SerializeField]
        private CharacterPart _characterPart;
  
        private void Awake()
        {
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            UIEvent<OnItemTypeSelected, CharacterPart>.Instance.Invoke(_characterPart);

        }
    }
}
