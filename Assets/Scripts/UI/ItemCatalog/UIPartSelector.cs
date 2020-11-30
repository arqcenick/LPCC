using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.ItemCatalog
{
    public class UIPartSelector : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            UIEvent<OnCharacterPartSelected, int>.Instance.Invoke(transform.GetSiblingIndex());
        }
    }
}