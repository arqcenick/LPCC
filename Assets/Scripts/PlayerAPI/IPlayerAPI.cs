using System.Collections.Generic;
using CharacterCustomizer;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace PlayerAPI
{
    public static class SPAPI
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void Init()
        {
            _instance = new MockPlayerAPI();
        }
        
        public static IPlayerAPI Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MockPlayerAPI();
                }

                return _instance;
            }
        }

        private static IPlayerAPI _instance;
    }
    
    public interface IPlayerAPI
    {
        PlayerPartAsset.CharacterClass GetDefaultCharacterClass();
        int GetLavaCoin();

        void AddLavaCoin(int amount);

        void SetLavaCoin(int amount);

        void SaveCharacter(CharacterData copy);

        CharacterData LoadCharacter(PlayerPartAsset.CharacterClass characterClass);

        bool IsLoadComplete();

    }
    
    public class MockPlayerAPI : IPlayerAPI
    {
        private int _lavaCoins;
        private Dictionary<PlayerPartAsset.CharacterClass, CharacterData> _characterDataDict = new Dictionary<PlayerPartAsset.CharacterClass, CharacterData>();
        private AsyncOperationHandle<IList<CharacterDataAsset>> _loadHandle;

        public MockPlayerAPI()
        {
            LoadDefaultCharacters();
        }
        public PlayerPartAsset.CharacterClass GetDefaultCharacterClass()
        {
            return PlayerPartAsset.CharacterClass.Marksman;
        }

        public int GetLavaCoin()
        {
            return _lavaCoins;
        }

        public void AddLavaCoin(int amount)
        {
            _lavaCoins += amount;
        }

        public void SetLavaCoin(int amount)
        {
            _lavaCoins = 0;
        }

        public void SaveCharacter(CharacterData copy)
        {
            _characterDataDict[copy.Class] = copy;
        }

        public CharacterData LoadCharacter(PlayerPartAsset.CharacterClass characterClass)
        {
            return _characterDataDict[characterClass].Copy();
        }

        public bool IsLoadComplete()
        {
            return _loadHandle.IsDone;
        }

        private void LoadDefaultCharacters()
        {
            _loadHandle = Addressables.LoadAssetsAsync<CharacterDataAsset>(new AssetLabelReference
            {
                labelString = "Heroes",
            }, asset => { });
            _loadHandle.Completed += OnCharactersLoaded;
        }
        private void OnCharactersLoaded(AsyncOperationHandle<IList<CharacterDataAsset>> characterAssets)
        {
            if (characterAssets.Status == AsyncOperationStatus.Succeeded)
            {
                foreach (var characterAsset in characterAssets.Result)
                {
                    Debug.Log(characterAsset.CharacterClass);
                    _characterDataDict[characterAsset.CharacterClass] = new CharacterData(characterAsset);
                }
            }
        }
        

    }
}