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

    public string Name => _name;

    public string Description => _description;

    public Sprite HeroIcon => _heroIcon;
    public Sprite[] TraitIcons => _traitIcons;
    public string Summary => _summary;

    [SerializeField]
    private List<CharacterSkinAsset> _characterSkinsPartValues;

    [SerializeField] 
    private List<CharacterItemAsset> _characterItemAssets;

    [SerializeField] 
    private PlayerPartAsset.CharacterClass _characterClass;

    [SerializeField] 
    private string _name;

    [SerializeField]
    private string _description;

    [SerializeField] 
    private Sprite _heroIcon;

    [SerializeField]
    private Sprite[] _traitIcons;

    [SerializeField]
    private string _summary;
}
