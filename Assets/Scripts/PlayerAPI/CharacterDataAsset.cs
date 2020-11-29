using System;
using System.Collections.Generic;
using CharacterCustomizer;
using UnityEngine;

[CreateAssetMenu(menuName = "LPCC/CharacterDataAsset", fileName = "CharacterDataAsset", order = 4)]
public class CharacterDataAsset : ScriptableObject
{
    public IReadOnlyList<CharacterSkinAsset> CharacterSkinAssets => _characterSkinsPartValues;
    [SerializeField]
    private List<CharacterSkinAsset> _characterSkinsPartValues;
}
