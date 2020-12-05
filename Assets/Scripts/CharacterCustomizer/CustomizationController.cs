using System;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterCustomizer
{
    public class CustomizationController : MonoBehaviour
    {
        private static readonly int PantsTex = Shader.PropertyToID("PantsTex");
        private static readonly int TorsoTex = Shader.PropertyToID("TorsoTex");
        private static readonly int ShoesTex = Shader.PropertyToID("ShoesTex");
        private static readonly int SkinTex = Shader.PropertyToID("SkinTex");
        private static readonly int BeardTex = Shader.PropertyToID("BeardTex");
        private static readonly int GlovesTex = Shader.PropertyToID("GlovesTex");

        
        private SkinnedMeshRenderer _meshRenderer;
        private Dictionary<CharacterItemPart, MeshItem> _meshItems = new Dictionary<CharacterItemPart, MeshItem>();

        private void Awake()
        {
            var componentsInChildren = GetComponentsInChildren<MeshItem>();
            foreach (var meshItem in componentsInChildren)
            {
                _meshItems[meshItem.ItemPart] = meshItem;
            }
            _meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
            GameEventSingleton<OnCharacterModelDataUpdated, CharacterData>.Instance.AddListener(SetCharacterModel);
        }

        public void SetCharacterModel(CharacterData data)
        {
            foreach (var skinAsset in data.CharacterSkinAssets)
            {
                SetCharacterSkinAsset(skinAsset.Value);   
            }

            foreach (var itemAsset in data.CharacterItemAssets)
            {
                SetCharacterItemAsset(itemAsset.Value);
            }
        }


        public void SetCharacterItemAsset(CharacterItemAsset item)
        {
            _meshItems[item.CharacterItemPart].SetItem(item);
        }

        public void SetCharacterSkinAsset(CharacterSkinAsset skin)
        {
            switch (skin.CharacterSkinPart)
            {
                case CharacterSkinPart.Skin:
                    _meshRenderer.material.SetTexture(SkinTex, skin.BaseMap);
                    break;
                case CharacterSkinPart.Eye:
                    break;
                case CharacterSkinPart.Eyebrow:
                    break;
                case CharacterSkinPart.Beard:
                    _meshRenderer.material.SetTexture(BeardTex, skin.BaseMap);

                    break;
                case CharacterSkinPart.Hair:
                    break;
                case CharacterSkinPart.Scar:
                    break;
                case CharacterSkinPart.FaceFeature:
                    break;
                case CharacterSkinPart.Head:
                    break;
                case CharacterSkinPart.Pants:
                    _meshRenderer.material.SetTexture(PantsTex, skin.BaseMap);
                    break;
                case CharacterSkinPart.Torso:
                    _meshRenderer.material.SetTexture(TorsoTex, skin.BaseMap);
                    break;
                case CharacterSkinPart.Shoe:
                    _meshRenderer.material.SetTexture(ShoesTex, skin.BaseMap);
                    break;
                case CharacterSkinPart.Glove:
                    _meshRenderer.material.SetTexture(GlovesTex, skin.BaseMap);
                    break;
                case CharacterSkinPart.Belt:
                    break;
                case CharacterSkinPart.RobeLong:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}