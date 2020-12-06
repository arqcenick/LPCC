using System;
using System.Linq;
using CharacterCustomizer;
using UI.ItemCatalog;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TypeSelectionController : MonoBehaviour
    {
        
        private UIItemTypeSelector[] _selectors;

        private void Awake()
        {
            UIEventSingleton<ForceItemTypeSelected, CharacterPart>.Instance.AddListener(OnPartSelect);
        }

        private void OnPartSelect(CharacterPart part)
        {
            _selectors.First(x=>x.CharacterPart == part).EmulateClick();
        }

        private void Start()
        {
            _selectors = GetComponentsInChildren<UIItemTypeSelector>();
            
            // _toggles = GetComponentsInChildren<Toggle>();
            // _toggles
            //     .First(x => x.GetComponent<UIItemTypeSelector>().CharacterPart == CharacterPart.Helmet)
            //     .isOn = true;
        }
    }
}
