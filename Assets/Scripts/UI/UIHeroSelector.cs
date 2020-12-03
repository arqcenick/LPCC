using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHeroSelector : MonoBehaviour
{
    private void Awake()
    {
        RectTransform rectTransform = transform as RectTransform;
        var position = rectTransform.transform.position;
        position.x  = rectTransform.position.x - rectTransform.rect.width * 2;
        rectTransform.transform.position = position;
    }
}
