using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Random = UnityEngine.Random;


public class TextureCreator : MonoBehaviour
{
    [SerializeField]
    private int _textureCount = 3;
    [SerializeField]
    private SkinnedMeshRenderer _renderer;
    private Texture2D[] _textures;
    private static readonly int Vector143E64Ce11Ec74Afaa02A24Ca38Eefc70 = Shader.PropertyToID("Vector1_43e64ce11ec74afaa02a24ca38eefc70");
    private int _currentIndex = 0;
    private void Awake()
    {
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CreateRandomTexture();
        }
    }

    private void CreateRandomTexture()
    {
        //_currentIndex = (_currentIndex+1) % _textureCount;
        //_renderer.material.mainTexture = 
        
        // Texture2D texture2D = new Texture2D(1024, 1024);
        // var headPixels = GetHeadTexture(Random.Range(0, _textureCount));
        // texture2D.SetPixels(0, 535, 642, 489, headPixels);
        // texture2D.Apply();
        // _renderer.material.mainTexture = texture2D;
        
    }

    private Color[] GetHeadTexture(int index)
    {
        
        return _textures[index].GetPixels(0, 535, 642, 489);
    }

    private IEnumerator LoadAllTextures()
    {
        _textures = new Texture2D[3];
    
        for (int i = 0; i < _textureCount; i++)
        {
            var handle = Addressables.LoadAssetAsync<Texture2D>((i+1).ToString());
    
            yield return handle;
    
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                _textures[i] = handle.Result;
            }
        }
    }
}
