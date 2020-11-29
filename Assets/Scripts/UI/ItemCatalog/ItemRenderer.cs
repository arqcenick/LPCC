﻿using System.Collections;
using CharacterCustomizer;
using UI.ItemCatalog;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UI;

namespace UI
{
    public class ItemRenderer : MonoBehaviour
    {


        [SerializeField]
        private CustomizationController _itemMannequin;

        [SerializeField] 
        private RenderTexture _mannequinTexture;

        public static ItemRenderer Instance;

        // public void GetTexturesOfSkins(CharacterSkinAsset[] skins, UISkinElement[] elements)
        // {
        //     Texture2D[] result = new Texture2D[skins.Length];
        //
        //     //var texture = new Texture2D(_mannequinTexture.width, _mannequinTexture.height, _mannequinTexture.graphicsFormat, TextureCreationFlags.None);
        //     StartCoroutine(GetTextureOfSkin(skins, elements, 0));
        //     
        // }
        //
        // public IEnumerator GetTextureOfSkin(CharacterSkinAsset[] skins, UISkinElement[] elements, int index)
        // {
        //     var element = elements[index];
        //     var skin = skins[index];
        //     _itemMannequin.SetCharacterSkinAsset(skin);
        //     yield return new WaitForEndOfFrame();
        //     Graphics.CopyTexture(_mannequinTexture, element.Image.texture);
        //     yield return new WaitForSeconds(5);
        //     if (index < skins.Length - 1)
        //     {
        //         StartCoroutine(GetTextureOfSkin(skins, elements, index + 1));
        //     }
        // }
        
        public IEnumerator GetTextureOfSkin(CharacterSkinAsset skinAsset, Texture texture)
        {

            _itemMannequin.SetCharacterSkinAsset(skinAsset);
            yield return new WaitForEndOfFrame();
            Graphics.CopyTexture(_mannequinTexture, texture);

        }
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            Instance = this;
        }


        public Texture GetTextureOfItem(ref CharacterItemAsset item)
        {
            return new Texture2D(1024,1024);
        }
    }
}