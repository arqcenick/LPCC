using UnityEngine;

public class UIItemSelector : MonoBehaviour
{
    private void Start()
    {
        RectTransform rectTransform = transform as RectTransform;
        var position = rectTransform.transform.position;
        position.x  = rectTransform.position.x + rectTransform.rect.width * 2;
        rectTransform.transform.position = position;
    }
}