using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.TestTools;

namespace Tests
{
    public class textures_are_loaded
    {
        [UnityTest]
        public IEnumerator load_single_texture()
        {
            var handle = Addressables.LoadAssetAsync<Texture2D>("Pant0");

            int iterator = 0;
            while (!handle.IsDone && iterator < 1000)
            {
                yield return null;

            }
            var texture = handle.Result;

            Debug.Assert(new Vector2(texture.width, texture.height) == new Vector2(512, 576));

        }
        [UnityTest]
        public IEnumerator load_all_outfit_textures()
        {

            var reference = new AssetLabelReference();
            reference.labelString = "OutfitTextures";
            
            var handle = Addressables.LoadAssetsAsync<Texture2D>(reference, (x)=>{});

            int iterator = 0;
            while (!handle.IsDone && iterator < 1000)
            {
                yield return null;

            }
            var texture = handle.Result[0];

            Debug.Assert(new Vector2(texture.width, texture.height) == new Vector2(512, 576));

        }
        
    }
}
