using CharacterCustomizer;
using UnityEngine;
using UnityEngine.Serialization;


public abstract class CharacterPartAsset : ScriptableObject
{
    
}

[CreateAssetMenu(menuName = "LPCC/CharacterItemAsset", fileName = "CharacterItemAsset", order = 1)]

public class CharacterItemAsset : CharacterPartAsset
{
    
}

[CreateAssetMenu(menuName = "LPCC/CharacterSkinAsset", fileName = "CharacterSkinAsset", order = 0)]
public class CharacterSkinAsset : CharacterPartAsset
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

    
    public Texture BaseMap;
    
    [SerializeField]
    private string _name = "default_item";
    

    
    [FormerlySerializedAs("_characterPart")] [SerializeField]
    private CharacterSkinPart characterSkinPart;

    public CharacterSkinPart CharacterSkinPart => characterSkinPart;
}