using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace UI
{
    public class UIHeroSelector : MonoBehaviour
    {
        private HeroSelectorButton[] _buttons;
        private List<CharacterDataAsset> _characterData;
        private void Awake()
        {
            _buttons = GetComponentsInChildren<HeroSelectorButton>();
            RectTransform rectTransform = transform as RectTransform;
            var position = rectTransform.transform.position;
            position.x  = rectTransform.position.x - rectTransform.rect.width * 2;
            rectTransform.transform.position = position;
        
            Addressables.LoadAssetsAsync<CharacterDataAsset>(new AssetLabelReference
            {
                labelString = "Heroes",
            }, asset => {} ).Completed += OnCharactersLoaded;
        }

        private void OnCharactersLoaded(AsyncOperationHandle<IList<CharacterDataAsset>> characters)
        {
            _characterData = characters.Result.ToList();
            LoadHeroUI();
        }

        public void LoadHeroUI()
        {
            for (int i = 0; i < _characterData.Count; i++)
            {
                _buttons[i].SetHero(_characterData[i]);
            }
        }
    }
}