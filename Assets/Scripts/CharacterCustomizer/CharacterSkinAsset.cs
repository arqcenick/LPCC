using System;
using CharacterCustomizer;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "LPCC/CharacterItemAsset", fileName = "CharacterItemAsset", order = 1)]

public class CharacterItemAsset : ScriptableObject
{
    
}

[CreateAssetMenu(menuName = "LPCC/CharacterSkinAsset", fileName = "CharacterSkinAsset", order = 0)]
public class CharacterSkinAsset : ScriptableObject
{
    protected bool Equals(CharacterSkinAsset other)
    {
        return base.Equals(other) && _name == other._name;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((CharacterSkinAsset) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return (base.GetHashCode() * 397) ^ (_name != null ? _name.GetHashCode() : 0);
        }
    }

    [Flags]
    public enum CharacterClass
    {
        None = 0,
        Marksman = 1,
        Arcanum = 2,
    }

    
    public Texture BaseMap;
    
    [SerializeField]
    private string _name = "default_item";
    
    [SerializeField]
    private CharacterClass _characterClass = CharacterClass.Arcanum;
    
    [FormerlySerializedAs("_characterPart")] [SerializeField]
    private CharacterSkinPart characterSkinPart;

    [SerializeField] 
    private int UnlockCost;

    [SerializeField] 
    private bool IsUnlocked = true;

    public CharacterSkinPart CharacterSkinPart => characterSkinPart;
}