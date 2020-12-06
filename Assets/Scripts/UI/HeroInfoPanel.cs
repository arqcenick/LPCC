using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroInfoPanel : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI _nameText;
    
    [SerializeField]
    private TextMeshProUGUI _descriptionText;

    [SerializeField] 
    private TextMeshProUGUI _summaryText;

    [SerializeField] 
    private Image[] _icons;

    private CanvasGroup _canvasGroup;
    private void Awake()
    {
        _canvasGroup = GetComponentInChildren<CanvasGroup>();
        UIEventSingleton<OnHeroSelected, CharacterDataAsset>.Instance.AddListener(OnHeroChanged);
    }

    private void OnHeroChanged(CharacterDataAsset hero)
    {

        _canvasGroup.DOFade(0, 0.2f).OnComplete(() =>
        {
            _nameText.text = hero.Name;
            _descriptionText.text = hero.Description;
            for (int i = 0; i < _icons.Length; i++)
            {
                _icons[i].sprite = hero.TraitIcons[i];
            }
            _summaryText.text = hero.Summary;
            _canvasGroup.DOFade(1, 0.2f);
        });


    }
}
