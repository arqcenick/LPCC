using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI.ItemCatalog
{
    public class UISelectionColor : MonoBehaviour
    {
        [SerializeField] 
        private Image _selectionImage;
        [SerializeField] 
        private Image _iconImage;


        [SerializeField] 
        private Color _selectedColor;
        [SerializeField] 
        private Color _selectedIconColor;

        private Color _originalColor;
        private Color _originalIconColor;
        private Toggle _toggle;
        private void Awake()
        {
            _toggle = GetComponentInParent<Toggle>();
            _toggle.onValueChanged.AddListener(OnSelectionChanged);

            _originalColor = _selectionImage.color;
            _originalIconColor = _iconImage.color;
        }

        private void Start()
        {
            OnSelectionChanged(_toggle.isOn);
        }

        public void OnSelectionChanged(bool isSelected)
        {
            if (isSelected)
            {
                _selectionImage.DOKill();
                _selectionImage.DOColor(_selectedColor, 0.25f);
                _iconImage.DOKill();
                _iconImage.DOColor(_selectedIconColor, 0.25f);
            }
            else
            {
                _selectionImage.DOKill();
                _selectionImage.DOColor(_originalColor, 0.25f);
                _iconImage.DOKill();
                _iconImage.DOColor(_originalIconColor, 0.25f);

            }
        }
    
     
    }
}