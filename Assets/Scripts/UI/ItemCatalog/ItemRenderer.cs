using System;
using System.Collections;
using CharacterCustomizer;
using UnityEngine;

namespace UI.ItemCatalog
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
            _itemMannequin.SetWeaponVisibility(false);
            switch (asset)
            {
                case CharacterItemAsset characterItemAsset:
                    _itemMannequin.SetCharacterItemAsset(characterItemAsset);
                    if (characterItemAsset.CharacterItemPart == CharacterItemPart.Weapon1)
                    {
                        _itemMannequin.SetWeaponVisibility(true);
                        _itemMannequin.SetCharacterVisibility(false);

                    }
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
            _itemMannequin.SetCharacterVisibility(true);

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