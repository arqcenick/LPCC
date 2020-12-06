using System;
using System.Collections;
using CharacterCustomizer;
using UI.ItemCatalog;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UI;

namespace UI
{
    public class ItemRenderer : MonoBehaviour
    {
        [SerializeField] 
        private RenderTexture _mannequinTexture;

        private CustomizationController _itemMannequin;

        public static ItemRenderer Instance;
        
        
        public IEnumerator GetTextureOfPart(CharacterPartAsset asset, Texture texture)
        {
            _itemMannequin.ResetModel();
            switch (asset)
            {
                case CharacterItemAsset characterItemAsset:
                    _itemMannequin.SetCharacterItemAsset(characterItemAsset);
                    break;
                case CharacterSkinAsset characterSkinAsset:
                    if (characterSkinAsset.CharacterSkinPart == CharacterSkinPart.Pants)
                    {
                        _itemMannequin.SetRobeVisibility(false);
                    }
                    _itemMannequin.SetCharacterSkinAsset(characterSkinAsset);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(asset));
            }
            
            yield return new WaitForEndOfFrame();
            _itemMannequin.SetRobeVisibility(true);

            Graphics.CopyTexture(_mannequinTexture, texture);

        }
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            Instance = this;
            _itemMannequin = GetComponentInChildren<CustomizationController>();
        }
        
    }
}