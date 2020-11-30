using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CharacterCustomizer;
using UnityEngine;

namespace UI.ItemCatalog
{
    public class UIItemCatalog : MonoBehaviour
    {
        
        
        private List<UISkinElement> _partElements;

        private CharacterPart _currentCatalogPage;
        private void Awake()
        {
            _partElements = GetComponentsInChildren<UISkinElement>().ToList();

            UIEvent<OnItemTypeSelected, CharacterPart>.Instance.AddListener(OnItemTypeSelected);
        }

        private void OnItemTypeSelected(CharacterPart characterPart)
        {
            StartCoroutine(GatherTextures(characterPart));
        }

        private void OnItemSelected(int index)
        {
            
        }
        
        private IEnumerator GatherTextures(CharacterPart characterPart)
        {
            if (_currentCatalogPage == characterPart)
            {
                yield break;
            }
            
            if (characterPart > CharacterPart.EndOfSkins)
            {
                
            }
            else
            {
                CharacterSkinPart skinPart = (CharacterSkinPart) characterPart;
                Debug.Log(skinPart);
                var skinAssets = TextureLoader.Instance.SkinDictionary[skinPart];
                var elements = new UISkinElement[skinAssets.Count];
                for (int i = 0; i < _partElements.Count; i++)
                {
                    if (i < skinAssets.Count)
                    {
                        _partElements[i].gameObject.SetActive(true);
                        _partElements[i].SetSkin(skinAssets[i]);
                        yield return new WaitForEndOfFrame();
                        elements[i] = _partElements[i];
                    }
                    else
                    {
                        _partElements[i].gameObject.SetActive(false);
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
