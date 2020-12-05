using System;
using System.Collections;
using CharacterCustomizer;
using UnityEngine;

namespace UI.ItemCatalog
{
    public class UIItemCatalog : MonoBehaviour
    {
        [SerializeField] 
        private bool _isAlternative = false; 
        
        private UIItemContainer[] _itemContainers;
        private UIItemContainer _activeContainer;
        private int _activeContainerIndex = 0;
        private CharacterPart _currentCatalogPage;
        
        private void Awake()
        {

            SetActiveContainers();

            UIEventSingleton<OnItemTypeSelected, CharacterPart>.Instance.AddListener(OnItemTypeSelected);
            //UIEventSingleton.EventBus[OnCharacterPartSelected].Instance.AddListener(OnItemSelected);
            
            
        }

        private void SetActiveContainers()
        {
            _itemContainers = GetComponentsInChildren<UIItemContainer>();
            _activeContainer = _itemContainers[_activeContainerIndex];

        }

        private void OnItemTypeSelected(CharacterPart characterPart)
        {
            //Handle alternative case.

            
            if (_currentCatalogPage != characterPart)
            {
                _currentCatalogPage = characterPart;
                _activeContainer.Hide();
                _activeContainerIndex = (_activeContainerIndex + 1) % _itemContainers.Length;
                _activeContainer = _itemContainers[_activeContainerIndex];
                if (_isAlternative)
                {
                    characterPart = UIAlternativeConverter.GetAlternativePart(characterPart);
                    if (characterPart == CharacterPart.Invalid)
                    {
                        
                        return;
                    }
                }
                _activeContainer.Show();
                StartCoroutine(GatherTextures(characterPart));

            }
        }

        private void OnItemSelected(int index)
        {
            var partAsset = _activeContainer.PartElements[index].Part;
            GameEventSingleton<OnCharacterPartModified, CharacterPartAsset>.Instance.Invoke(partAsset);
        }
        
        private IEnumerator GatherTextures(CharacterPart characterPart)
        {
            
            if (characterPart > CharacterPart.EndOfSkins)
            {
                CharacterItemPart itemPart = (CharacterItemPart) characterPart- (int) CharacterPart.EndOfSkins - 1;
                var itemAssets = TextureLoader.Instance.PartDictionary[itemPart];
                var partElements = _activeContainer.PartElements;
                for (int i = 0; i < partElements.Count; i++)
                {
                    if (i < itemAssets.Count)
                    {
                        partElements[i].gameObject.SetActive(true);
                        partElements[i].SetPart(itemAssets[i]);
                        yield return new WaitForEndOfFrame();
                    }
                    else
                    {
                        partElements[i].gameObject.SetActive(false);
                    }
                    
                
                }
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
                        partElements[i].SetPart(skinAssets[i]);
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
