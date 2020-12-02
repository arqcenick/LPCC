using System;
using System.Collections;
using CharacterCustomizer;
using UnityEngine;

namespace UI.ItemCatalog
{
    public class UIItemCatalog : MonoBehaviour
    {
        private UIItemContainer[] _itemContainers;
        private UIItemContainer _activeContainer;
        private int _activeContainerIndex = 0;
        private CharacterPart _currentCatalogPage;

        private void Awake()
        {

            SetActiveContainers();

            UIEvent<OnItemTypeSelected, CharacterPart>.Instance.AddListener(OnItemTypeSelected);
            UIEvent<OnCharacterPartSelected, int>.Instance.AddListener(OnItemSelected);
            
            
        }

        private void SetActiveContainers()
        {
            _itemContainers = GetComponentsInChildren<UIItemContainer>();
            _activeContainer = _itemContainers[_activeContainerIndex];

        }

        private void OnItemTypeSelected(CharacterPart characterPart)
        {
            if (_currentCatalogPage != characterPart)
            {
                _currentCatalogPage = characterPart;

                //_activeContainer.gameObject.SetActive(false);
                _activeContainer.Hide();
                
                _activeContainerIndex = (_activeContainerIndex + 1) % _itemContainers.Length;
                _activeContainer = _itemContainers[_activeContainerIndex];   
                _activeContainer.Show();

                StartCoroutine(GatherTextures(characterPart));

            }

        }

        private void OnItemSelected(int index)
        {
            var skinAsset = _activeContainer.PartElements[index].Skin;
            GameEvent<OnCharacterSkinModified, CharacterSkinAsset>.Instance.Invoke(skinAsset);
        }
        
        private IEnumerator GatherTextures(CharacterPart characterPart)
        {
            
            if (characterPart > CharacterPart.EndOfSkins)
            {
                
            }
            else if(TextureLoader.Instance.SkinDictionary.ContainsKey((CharacterSkinPart) characterPart))
            {
                CharacterSkinPart skinPart = (CharacterSkinPart) characterPart;
                var skinAssets = TextureLoader.Instance.SkinDictionary[skinPart];
                var partElements = _activeContainer.PartElements;
                for (int i = 0; i < partElements.Count; i++)
                {
                    if (i < skinAssets.Count)
                    {
                        partElements[i].gameObject.SetActive(true);
                        partElements[i].SetSkin(skinAssets[i]);
                        yield return new WaitForEndOfFrame();
                    }
                    else
                    {
                        partElements[i].gameObject.SetActive(false);
                    }
                    
                
                }
                //ItemRenderer.Instance.GetTexturesOfSkins(skinAssets.ToArray(),elements);


            }
            
  
            
        }

        private void OnEnable()
        {
        }

        private void OnDisable()
        {
            
        }
    }
}
