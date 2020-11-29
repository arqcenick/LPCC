using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using UnityEngine.ResourceManagement.AsyncOperations;
using Random = UnityEngine.Random;


namespace CharacterCustomizer
{
    public class OnCharacterModelDataUpdated : UnityEvent<CharacterData>
    {
    
    }
    
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
        Skin = 0,
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

    public enum CharacterItemPart
    {
        Helmet,
        ShoulderArmor,
        TorsoArmor,
        BottomArmor,
    }
    
    public class CharacterCreator : MonoBehaviour
    {
        [SerializeField] 
        private CharacterDataAsset _characterDataAsset;
        
        private CharacterData _characterData;
        
        private void Start()
        {
            _characterData = new CharacterData();
            _characterData.CharacterSkinAssets = LoadDefaultCharacterSkins();
            _characterData.CharacterItemAssets = LoadDefaultCharacterItems();
            UpdateModel();
        }

        private void UpdateModel()
        {
            GameEvent<OnCharacterModelDataUpdated, CharacterData>.Instance.Invoke(_characterData);
        }

        private IReadOnlyDictionary<CharacterItemPart, CharacterPartAsset> LoadDefaultCharacterItems()
        {

            return null;
        }

        private IReadOnlyDictionary<CharacterSkinPart, CharacterSkinAsset> LoadDefaultCharacterSkins()
        {
            Dictionary<CharacterSkinPart, CharacterSkinAsset> parts = new Dictionary<CharacterSkinPart, CharacterSkinAsset>();
            foreach (var characterSkinAsset in _characterDataAsset.CharacterSkinAssets)
            {
                if (characterSkinAsset != null)
                {
                    parts[characterSkinAsset.CharacterSkinPart] = characterSkinAsset;
                }
            }

            return parts;
        }
        
        
    }
}
