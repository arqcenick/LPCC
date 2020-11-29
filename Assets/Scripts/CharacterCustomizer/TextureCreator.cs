using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


namespace CharacterCustomizer
{

    public enum CharacterPart
    {
        Skin,
        Eye,
        Eyebrow,
        Beard,
        Hair,
        Scar,
        FaceFeature,
        Head,
        Pants,
        Torso,
        Shoe,
        Glove,
        Belt,
        RobeLong,
        EndOfSkins,
        Helmet,
        ShoulderArmor,
        TorsoArmor,
        BottomArmor,

    }
    public enum CharacterSkinPart
    {
        Skin,
        Eye,
        Eyebrow,
        Beard,
        Hair,
        Scar,
        FaceFeature,
        Head,
        Pants,
        Torso,
        Shoe,
        Glove,
        Belt,
        RobeLong,
    }
    
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
            if(Input.GetKeyDown(KeyCode.X))
            {

                var legTextures = TextureLoader.Instance.SkinDictionary[CharacterSkinPart.Pants];
                var legTexture = legTextures[Random.Range(0, legTextures.Count)];
                GetComponent<CustomizationController>().SetCharacterSkinAsset(legTexture);

                //CreateRandomTexture();
            }
        }

        private void CreateRandomTexture()
        {



            var legTextures = TextureLoader.Instance.SkinDictionary[CharacterSkinPart.Pants];
            var legTexture = legTextures[Random.Range(0, legTextures.Count)];
            var legPixels = (legTexture.BaseMap as Texture2D).GetPixels(0,0,500,200);
            for (int l = 0; l < 1000; l++)
            {
                Debug.Log(legPixels[l].a);
            }
            Debug.Log(legTexture.BaseMap.graphicsFormat);
            Texture2D texture2D = new Texture2D(1024, 1024, TextureFormat.RGBA32, false);
            texture2D.SetPixels32(((Texture2D) _renderer.material.mainTexture).GetPixels32());

            texture2D.SetPixels(0, 0, 500, 200, legPixels);

            texture2D.Apply();
            _renderer.material.mainTexture = texture2D;
            Debug.Log(_renderer.material.mainTexture.graphicsFormat);
            

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
}
