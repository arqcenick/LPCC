using System;
using System.Collections;
using CharacterCustomizer;
using UnityEngine;
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
    
    public class UISkinElement : UIPartElement
    {
        public CharacterPartAsset Part => _part;
        private CharacterPartAsset _part;

        private void Awake()
        {
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
        
    }
}