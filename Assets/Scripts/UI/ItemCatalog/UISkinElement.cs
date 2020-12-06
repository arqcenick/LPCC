using System;
using System.Collections;
using CharacterCustomizer;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI.ItemCatalog
{
    
    public abstract class UIPartElement : MonoBehaviour
    {
        [FormerlySerializedAs("image")] [FormerlySerializedAs("_image")] [SerializeField]
        public RawImage Image;
        public abstract void UpdatePart();

    }
    
    public class UISkinElement : UIPartElement, IPointerClickHandler
    {
        public CharacterPartAsset Part => _part;
        private CharacterPartAsset _part;
        private Toggle _toggle;
        private void Awake()
        {
            _toggle = GetComponent<Toggle>();
            Image.texture = new Texture2D(512,512, TextureFormat.RGBA32, false);
        }

        public void SetPart(CharacterPartAsset partAsset)
        {
            _part = partAsset;
            UpdatePart();
        }

        public override void UpdatePart()
        {
            StartCoroutine(ItemRenderer.Instance.GetTextureOfPart(_part, Image.texture));
            
        }

        public void EmulateClick()
        {
            OnPointerClick(null);
            _toggle.isOn = true;
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            
            GameEventSingleton<OnCharacterPartModified, CharacterPartAsset>.Instance.Invoke(_part);
            UIEventSingleton<OnButtonClicked>.Instance.Invoke();

        }
        
    }
}