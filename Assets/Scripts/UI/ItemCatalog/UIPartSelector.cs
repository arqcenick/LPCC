using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.ItemCatalog
{
    public class UIPartSelector : MonoBehaviour
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
            OnValueChanged(_toggle.isOn);
        }

        private void OnValueChanged(bool val)
        {
            _selectionImage.DOFade(val ? 1 : 0 , 0.2f);
        }
    }
}