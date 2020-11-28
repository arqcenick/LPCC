using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;


// [CreateAssetMenu(fileName = "TextureAssetLocator")]
// public class TextureAssetLocator : ScriptableObject
// {
//     private enum Key;
// }

public class TextureLoader : MonoBehaviour
{
    [SerializeField] private AssetLabelReference _assetLabelReference; 

    private void Awake()
    {
        StartAsyncLoadTextures();
    }

    public AsyncOperationHandle StartAsyncLoadTextures()
    {
        
        return Addressables.LoadAssetsAsync<Texture2D>(_assetLabelReference, LoadTextures);
        
    }

    private void LoadTextures(Texture2D tex)
    {
        Debug.Log("Loaded: " + tex.name);
    }
}