using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.TestTools;

namespace Tests
{
    public class textures_are_loaded
    {
        [UnityTest]
        public IEnumerator load_all_outfit_textures()
        {

            var reference = new AssetLabelReference();
            reference.labelString = "OutfitTextures";
            
            var handle = Addressables.LoadAssetsAsync<CharacterSkinAsset>(reference, (x)=>{});

            int iterator = 0;
            while (!handle.IsDone && iterator < 1000)
            {
                yield return null;

            }
            
            foreach (var asset in handle.Result)
            {
                Debug.Assert(asset.BaseMap != null);
            }


        }
        
    }
}
