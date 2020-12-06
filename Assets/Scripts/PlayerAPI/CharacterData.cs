using System;
using System.Collections;
using System.Collections.Generic;
using CharacterCustomizer;
using PlayerAPI;



public class CharacterData
{
    public Dictionary<CharacterSkinPart, CharacterSkinAsset> CharacterSkinAssets;
    public Dictionary<CharacterItemPart, CharacterItemAsset> CharacterItemAssets;
    public PlayerPartAsset.CharacterClass Class;

    public CharacterData()
    {
        
    }
    public CharacterData(CharacterDataAsset asset)
    {
        CharacterItemAssets = new Dictionary<CharacterItemPart, CharacterItemAsset>();
        CharacterSkinAssets = LoadDefaultCharacterSkins(asset.CharacterClass, asset);
        CharacterItemAssets = LoadDefaultCharacterItems(asset.CharacterClass, asset);
        Class = asset.CharacterClass;

    }
    private Dictionary<CharacterItemPart, CharacterItemAsset> LoadDefaultCharacterItems(PlayerPartAsset.CharacterClass characterClass, CharacterDataAsset asset)
    {

        Dictionary<CharacterItemPart, CharacterItemAsset> parts = new Dictionary<CharacterItemPart, CharacterItemAsset>();
        var characterDataAsset = asset;
        foreach (var characterItemAsset in characterDataAsset.CharacterItemAssets)
        {
            if (characterItemAsset != null)
            {
                parts[characterItemAsset.CharacterItemPart] = characterItemAsset;
            }
        }
        return parts;
    }

    private Dictionary<CharacterSkinPart, CharacterSkinAsset> LoadDefaultCharacterSkins(PlayerPartAsset.CharacterClass characterClass, CharacterDataAsset asset)
    {
        Dictionary<CharacterSkinPart, CharacterSkinAsset> parts = new Dictionary<CharacterSkinPart, CharacterSkinAsset>();
        var characterDataAsset = asset;
        foreach (var characterSkinAsset in characterDataAsset.CharacterSkinAssets)
        {
            if (characterSkinAsset != null)
            {
                parts[characterSkinAsset.CharacterSkinPart] = characterSkinAsset;
            }
        }
        return parts;
    }
    public CharacterData Copy()
    {
        var cd = new CharacterData();
        cd.CharacterItemAssets = new Dictionary<CharacterItemPart, CharacterItemAsset>();
        foreach (var characterItemAsset in CharacterItemAssets)
        {
            cd.CharacterItemAssets[characterItemAsset.Key] = characterItemAsset.Value;
        }
        cd.CharacterSkinAssets = new Dictionary<CharacterSkinPart, CharacterSkinAsset>();

        foreach (var characterSkinAsset in CharacterSkinAssets)
        {
            cd.CharacterSkinAssets[characterSkinAsset.Key] = characterSkinAsset.Value;
        }

        cd.Class = Class;
        return cd;
    }
}
