using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class EditorPlayerPartCreator : Editor
{
    [MenuItem("LPCC/Create Player Parts")]
    public static void CreatePlayerParts()
    {

        ClearAssets();
        AssetDatabase.CreateFolder("Assets/ItemData", "Parts");
        var alr = new AssetLabelReference();
        alr.labelString = "OutfitTextures";
        
        var handle = Addressables.LoadAssetsAsync<CharacterSkinAsset>(alr, asset =>
        {
            Debug.Log("Loaded: " + asset.name);
        });

        Debug.Log("Creating...");

        IList<CharacterSkinAsset> skinAssets = new List<CharacterSkinAsset>();
        handle.Completed += operationHandle =>
        {
            skinAssets = operationHandle.Result;
            foreach (var skinAsset in skinAssets)
            {

                PlayerPartAsset pps = ScriptableObject.CreateInstance<PlayerPartAsset>();
                pps.CharacterPart = skinAsset;
                AssetDatabase.CreateAsset(pps, "Assets/ItemData/Parts/" + skinAsset.BaseMap.name +".asset");
            }
            Debug.Log("Done!");
        };
        
    }

    private static void ClearAssets()
    {
        AssetDatabase.DeleteAsset("Assets/ItemData/Parts");
    }
}
