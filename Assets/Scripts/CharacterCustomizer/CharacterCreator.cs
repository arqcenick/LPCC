using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Random = UnityEngine.Random;


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

    public enum CharacterItemPart
    {
        Helmet,
        ShoulderArmor,
        TorsoArmor,
        BottomArmor,
    }
    
    public class CharacterCreator : MonoBehaviour
    {
        private CharacterData _characterData;


        private void Start()
        {
            
            _characterData.CharacterSkinAssets = LoadDefaultCharacterSkins();
            _characterData.CharacterItemAssets = LoadDefaultCharacterItems();
            UpdateModel();
        }

        private void UpdateModel()
        {
            
        }

        private IReadOnlyDictionary<CharacterItemPart, CharacterPartAsset> LoadDefaultCharacterItems()
        {
            return new Dictionary<CharacterItemPart, CharacterPartAsset>();
        }

        private IReadOnlyDictionary<CharacterSkinPart, CharacterSkinAsset> LoadDefaultCharacterSkins()
        {
            return new Dictionary<CharacterSkinPart, CharacterSkinAsset>();
        }
        
        
    }
}
