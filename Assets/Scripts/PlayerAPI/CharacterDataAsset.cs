using System;
using System.Collections.Generic;
using CharacterCustomizer;
using UnityEngine;

[CreateAssetMenu(menuName = "LPCC/CharacterDataAsset", fileName = "CharacterDataAsset", order = 4)]
public class CharacterDataAsset : ScriptableObject
{
    public IReadOnlyList<CharacterSkinAsset> CharacterSkinAssets => _characterSkinsPartValues;
    public IReadOnlyList<CharacterItemAsset> CharacterItemAssets => _characterItemAssets;

    public PlayerPartAsset.CharacterClass CharacterClass => _characterClass;

    [SerializeField]
    private List<CharacterSkinAsset> _characterSkinsPartValues;

    [SerializeField] 
    private List<CharacterItemAsset> _characterItemAssets;

    [SerializeField] 
    private PlayerPartAsset.CharacterClass _characterClass;
}
