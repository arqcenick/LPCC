using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using UnityEngine.ResourceManagement.AsyncOperations;
using Random = UnityEngine.Random;


namespace CharacterCustomizer
{

    public class PlayerCharacterController : MonoBehaviour
    {
        //[SerializeField] 
        //private CharacterDataAsset _characterDataAsset;

        private Dictionary<PlayerPartAsset.CharacterClass, CharacterDataAsset> _playerCharacters = new Dictionary<PlayerPartAsset.CharacterClass, CharacterDataAsset>();
        
        private CharacterData _characterData;

        private void Awake()
        {
            GameEventSingleton<OnCharacterSkinModified, CharacterSkinAsset>.Instance.AddListener(OnCharacterSkinModified);
            Addressables.LoadAssetsAsync<CharacterDataAsset>(new AssetLabelReference
            {
                labelString = "Heroes",
            }, asset => {} ).Completed += OnCharactersLoaded;
        }

        private void OnCharactersLoaded(AsyncOperationHandle<IList<CharacterDataAsset>> characterAssets)
        {
            if (characterAssets.Status == AsyncOperationStatus.Succeeded)
            {
                foreach (var characterAsset in characterAssets.Result)
                {
                    _playerCharacters[characterAsset.CharacterClass] = characterAsset;
                }
            }

            InitializeModel();
        }
        

        private void InitializeModel()
        {
            _characterData = new CharacterData();
            _characterData.CharacterSkinAssets = LoadDefaultCharacterSkins();
            _characterData.CharacterItemAssets = LoadDefaultCharacterItems();
            UpdateModel();
        }

        private void OnCharacterSkinModified(CharacterSkinAsset asset)
        {
            _characterData.CharacterSkinAssets[asset.CharacterSkinPart] = asset;
            UpdateModel();
        }
        
        private void UpdateModel()
        {
            GameEventSingleton<OnCharacterModelDataUpdated, CharacterData>.Instance.Invoke(_characterData);
        }

        private Dictionary<CharacterItemPart, CharacterPartAsset> LoadDefaultCharacterItems()
        {

            return null;
        }

        private Dictionary<CharacterSkinPart, CharacterSkinAsset> LoadDefaultCharacterSkins()
        {
            Dictionary<CharacterSkinPart, CharacterSkinAsset> parts = new Dictionary<CharacterSkinPart, CharacterSkinAsset>();
            var characterDataAsset = _playerCharacters[0];
            foreach (var characterSkinAsset in characterDataAsset.CharacterSkinAssets)
            {
                if (characterSkinAsset != null)
                {
                    parts[characterSkinAsset.CharacterSkinPart] = characterSkinAsset;
                }
            }

            return parts;
        }
        

    }
    

}
