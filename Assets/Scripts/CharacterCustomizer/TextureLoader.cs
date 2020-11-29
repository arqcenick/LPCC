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

        
        private Dictionary<CharacterSkinPart, List<CharacterSkinAsset>> _skinDictionary = new Dictionary<CharacterSkinPart, List<CharacterSkinAsset>>();
    
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
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
        
            return Addressables.LoadAssetsAsync<CharacterSkinAsset>(_assetLabelReference, LoadSkins);
        
        }

        private void LoadSkins(CharacterSkinAsset skin)
        {
            Debug.Log("Loaded: " + skin.name);
            if (_skinDictionary.ContainsKey(skin.CharacterSkinPart))
            {
                _skinDictionary[skin.CharacterSkinPart].Add(skin);
            }
            else
            {
                _skinDictionary[skin.CharacterSkinPart] = new List<CharacterSkinAsset>
                {
                    skin,
                };
            }
        }
    }
}