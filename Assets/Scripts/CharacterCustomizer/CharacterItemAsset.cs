using CharacterCustomizer;
using UnityEngine;

[CreateAssetMenu(menuName = "LPCC/CharacterItemAsset", fileName = "CharacterItemAsset", order = 1)]

public class CharacterItemAsset : CharacterPartAsset
{
    protected bool Equals(CharacterItemAsset other)
    {
        return base.Equals(other) && Equals(ItemPrefab, other.ItemPrefab) && _name == other._name && _characterItemPart == other._characterItemPart;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((CharacterItemAsset) obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = base.GetHashCode();
            hashCode = (hashCode * 397) ^ (ItemPrefab != null ? ItemPrefab.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (_name != null ? _name.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (int) _characterItemPart;
            return hashCode;
        }
    }

    public GameObject ItemPrefab;
    public CharacterItemPart CharacterItemPart => _characterItemPart;
    [SerializeField]
    private string _name = "default_mesh_item";
    [SerializeField]
    private CharacterItemPart _characterItemPart;
}