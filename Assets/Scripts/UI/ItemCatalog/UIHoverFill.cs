using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIHoverFill : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] 
    private Image _fillImage; 
    private void OnMouseEnter()
    {
        // float fillAmount = Mathf.Clamp(_fillImage.fillAmount + Time.deltaTime, 0, 1);
        // _fillImage.fillAmount = fillAmount;

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _fillImage.DOKill();
        _fillImage.DOFillAmount(1, 0.2f).OnComplete(() =>
        {
            _fillImage.fillClockwise = false;
        });
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _fillImage.DOKill();
        _fillImage.DOFillAmount(0, 0.2f).OnComplete(() =>
        {
            _fillImage.fillClockwise = true;
        });
    }
    
}
