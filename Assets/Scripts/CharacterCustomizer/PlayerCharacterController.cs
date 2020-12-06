using System;
using System.Collections;
using System.Collections.Generic;
using PlayerAPI;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using UnityEngine.ResourceManagement.AsyncOperations;
using Random = UnityEngine.Random;

namespace CharacterCustomizer
{

    public class PlayerCharacterController : MonoBehaviour
    {

        public static PlayerCharacterController Instance;
        
        public CharacterData SelectedCharacterData => _characterData;

        //private Dictionary<PlayerPartAsset.CharacterClass, CharacterDataAsset> _playerCharacters = new Dictionary<PlayerPartAsset.CharacterClass, CharacterDataAsset>();
        
        private CharacterData _characterData;
        private CharacterData _savedCharacterData;

        private void Awake()
        {
            GameEventSingleton<OnCharacterPartModified, CharacterPartAsset>.Instance.AddListener(OnCharacterPartModified);
            UIEventSingleton<OnHeroSelected, CharacterDataAsset>.Instance.AddListener(ChangeCharacterDelegate);
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            StartCoroutine(OnLoadComplete());

        }

        private IEnumerator OnLoadComplete()
        {
            while (!SPAPI.Instance.IsLoadComplete())
            {
                yield return null;
            }
            _characterData = SPAPI.Instance.LoadCharacter(SPAPI.Instance.GetDefaultCharacterClass());
        }

        public IEnumerator SaveCharacterData()
        {
            while (!SPAPI.Instance.IsLoadComplete())
            {
                yield return null;
            }
            SPAPI.Instance.SaveCharacter(_characterData.Copy());
        }

        public void ConfirmCharacterChanges()
        {
            StartCoroutine(SaveCharacterData());
            UpdateModel();
        }

        public void RevertCharacterChanges()
        {
            _characterData = SPAPI.Instance.LoadCharacter(_characterData.Class);
            UpdateModel();

        }

        public void ChangeCharacterDelegate(CharacterDataAsset character)
        {
            StartCoroutine(ChangeCharacter(character));
        }
        public IEnumerator ChangeCharacter(CharacterDataAsset character)
        {
            while (!SPAPI.Instance.IsLoadComplete())
            {
                yield return null;
            }

            if (_characterData != null)
            {
                StartCoroutine(SaveCharacterData());
            }
            _characterData = SPAPI.Instance.LoadCharacter(character.CharacterClass);
            UpdateModel();
        }

 
        

        private void InitializeModel()
        {

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
        

       
        

    }
    

}
