using System;
using UnityEngine;

namespace CharacterCustomizer
{
    public class CustomizationController : MonoBehaviour
    {
        private SkinnedMeshRenderer _meshRenderer;
        private static readonly int PantsTex = Shader.PropertyToID("PantsTex");
        private static readonly int TorsoTex = Shader.PropertyToID("TorsoTex");
        private static readonly int ShoesTex = Shader.PropertyToID("ShoesTex");
        private static readonly int SkinTex = Shader.PropertyToID("SkinTex");

        private void Awake()
        {
            _meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
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