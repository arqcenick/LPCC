using System;
using System.Collections;
using System.Collections.Generic;
using CharacterCustomizer;


public class CharacterData
{
    public IReadOnlyDictionary<CharacterSkinPart, CharacterSkinAsset> CharacterSkinAssets;
    public IReadOnlyDictionary<CharacterItemPart, CharacterPartAsset> CharacterItemAssets;
}
