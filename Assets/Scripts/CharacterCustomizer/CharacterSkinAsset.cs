using CharacterCustomizer;
using UnityEngine;
using UnityEngine.Serialization;


[CreateAssetMenu(menuName = "LPCC/CharacterSkinAsset", fileName = "CharacterSkinAsset", order = 0)]
public class CharacterSkinAsset : CharacterPartAsset
{
    protected bool Equals(CharacterSkinAsset other)
    {
        return base.Equals(other) && Equals(BaseMap, other.BaseMap) && _name == other._name && characterSkinPart == other.characterSkinPart;
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
            int hashCode = base.GetHashCode();
            hashCode = (hashCode * 397) ^ (BaseMap != null ? BaseMap.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (_name != null ? _name.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (int) characterSkinPart;
            return hashCode;
        }
    }

    public Texture BaseMap;
    public CharacterSkinPart CharacterSkinPart => characterSkinPart;

    [SerializeField]
    private string _name = "default_item";


    [FormerlySerializedAs("_characterPart")] [SerializeField]
    private CharacterSkinPart characterSkinPart;
    
}