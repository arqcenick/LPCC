using System.Collections;
using System.Collections.Generic;
using CharacterCustomizer;
using UnityEngine;


public struct CharacterData
{
    public IReadOnlyDictionary<CharacterSkinPart, CharacterSkinAsset> CharacterSkinAssets;
    public IReadOnlyDictionary<CharacterItemPart, CharacterPartAsset> CharacterItemAssets;
}
