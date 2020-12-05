using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace CharacterCustomizer
{
    public class TextureLoader : MonoBehaviour
    {
        public static TextureLoader Instance;
    
        [SerializeField] private AssetLabelReference _assetLabelReference;

        public IReadOnlyDictionary<CharacterSkinPart, List<CharacterSkinAsset>> SkinDictionary => _skinDictionary;
        public IReadOnlyDictionary<CharacterItemPart, List<CharacterItemAsset>> PartDictionary => _partDictionary;


        private Dictionary<CharacterSkinPart, List<CharacterSkinAsset>> _skinDictionary = new Dictionary<CharacterSkinPart, List<CharacterSkinAsset>>();
        private Dictionary<CharacterItemPart, List<CharacterItemAsset>> _partDictionary = new Dictionary<CharacterItemPart, List<CharacterItemAsset>>();

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(this);
                return;
            }
            Instance = this;
            StartAsyncLoadTextures().Completed += OnLoadComplete;
        }

        private void OnLoadComplete(AsyncOperationHandle loadOperation)
        {
            Debug.Log("Load complete!");
        }


        public AsyncOperationHandle StartAsyncLoadTextures()
        {
            return Addressables.LoadAssetsAsync<CharacterPartAsset>(_assetLabelReference, LoadParts);
        }

        private void LoadParts(CharacterPartAsset skin)
        {
            switch (skin)
            {
                case CharacterItemAsset characterItemAsset:
                    if (_partDictionary.ContainsKey(characterItemAsset.CharacterItemPart))
                    {
                        _partDictionary[characterItemAsset.CharacterItemPart].Add(characterItemAsset);
                    }
                    else
                    {
                        _partDictionary[characterItemAsset.CharacterItemPart] = new List<CharacterItemAsset>
                        {
                            characterItemAsset,
                        };
                    }
                    break;
                case CharacterSkinAsset characterSkinAsset:
                    if (_skinDictionary.ContainsKey(characterSkinAsset.CharacterSkinPart))
                    {
                        _skinDictionary[characterSkinAsset.CharacterSkinPart].Add(characterSkinAsset);
                    }
                    else
                    {
                        _skinDictionary[characterSkinAsset.CharacterSkinPart] = new List<CharacterSkinAsset>
                        {
                            characterSkinAsset,
                        };
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(skin));
            }
 
        }
    }
}