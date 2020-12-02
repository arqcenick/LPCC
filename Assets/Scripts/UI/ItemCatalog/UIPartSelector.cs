using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.ItemCatalog
{
    public class UIPartSelector : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] 
        private Image _selectionImage;

        private Toggle _toggle;
        private void Awake()
        {
            _selectionImage.enabled = true;
            _selectionImage.DOFade(0, 0);
            _toggle = GetComponent<Toggle>();
            _toggle.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnValueChanged(bool val)
        {
            _selectionImage.DOFade(val ? 1 : 0 , 0.2f);
            
            Debug.Log("Value changed");
            // if (val)
            // {
            // }
            //
            // {
            //     _selectionImage.enabled = false;
            // }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            UIEvent<OnCharacterPartSelected, int>.Instance.Invoke(transform.GetSiblingIndex());
        }
    }
}