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
            GameEventSingleton<OnCharacterPartModified, CharacterPartAsset>.Instance.AddListener(OnCharacterPartModified);
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

        private void OnCharacterPartModified(CharacterPartAsset asset)
        {
            switch (asset)
            {
                case CharacterItemAsset characterItemAsset:
                    _characterData.CharacterItemAssets[characterItemAsset.CharacterItemPart] = characterItemAsset;
                    break;
                case CharacterSkinAsset characterSkinAsset:
                    _characterData.CharacterSkinAssets[characterSkinAsset.CharacterSkinPart] = characterSkinAsset;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(asset));
            }
            UpdateModel();
        }
        
        private void UpdateModel()
        {
            GameEventSingleton<OnCharacterModelDataUpdated, CharacterData>.Instance.Invoke(_characterData);
        }

        private Dictionary<CharacterItemPart, CharacterItemAsset> LoadDefaultCharacterItems()
        {

            Dictionary<CharacterItemPart, CharacterItemAsset> parts = new Dictionary<CharacterItemPart, CharacterItemAsset>();
            var characterDataAsset = _playerCharacters[PlayerPartAsset.CharacterClass.Marksman];
            foreach (var characterItemAsset in characterDataAsset.CharacterItemAssets)
            {
                if (characterItemAsset != null)
                {
                    parts[characterItemAsset.CharacterItemPart] = characterItemAsset;
                }
            }
            return parts;
        }

        private Dictionary<CharacterSkinPart, CharacterSkinAsset> LoadDefaultCharacterSkins()
        {
            Dictionary<CharacterSkinPart, CharacterSkinAsset> parts = new Dictionary<CharacterSkinPart, CharacterSkinAsset>();
            var characterDataAsset = _playerCharacters[PlayerPartAsset.CharacterClass.Marksman];
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
