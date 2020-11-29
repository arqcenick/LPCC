using UnityEngine;

[CreateAssetMenu(fileName = "TextureAssetType", menuName = "LPCC/TextureAssetType", order = 1)]
public class TextureAssetType : ScriptableObject
{
    [SerializeField] 
    private string _key;
    
    [SerializeField] 
    private int _textureOrder;
    
    public string Key => _key;

    public int TextureOrder => _textureOrder;
}