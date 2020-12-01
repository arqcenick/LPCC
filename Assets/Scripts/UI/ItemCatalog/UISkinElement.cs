using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI.ItemCatalog
{
    
    public abstract class UIPartElement : MonoBehaviour
    {
        [FormerlySerializedAs("image")] [FormerlySerializedAs("_image")] [SerializeField]
        public RawImage Image;
        public abstract void UpdateGraphic();
    }

    public class UIItemElement : UIPartElement
    {

        [SerializeField]
        public CharacterItemAsset _item;
        
        public override void UpdateGraphic()
        {
            ItemRenderer.Instance.GetTextureOfItem(ref _item);
        }
    }
    
    public class UISkinElement : UIPartElement
    {
        public CharacterSkinAsset Skin => _skin;
        private CharacterSkinAsset _skin;

        private void Awake()
        {
            Image.texture = new Texture2D(512,512, TextureFormat.RGBA32, false);
        }

        public void SetSkin(CharacterSkinAsset skinAsset)
        {
            _skin = skinAsset;
            UpdateGraphic();
        }

        public override void UpdateGraphic()
        {
            StartCoroutine(ItemRenderer.Instance.GetTextureOfSkin(_skin, Image.texture));
        }
    }
}