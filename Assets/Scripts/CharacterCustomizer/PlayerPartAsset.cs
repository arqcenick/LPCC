using System;
using UnityEngine;

[CreateAssetMenu(menuName = "LPCC/PlayerPartAsset", fileName = "PlayerPartAsset", order = 2)]
public class PlayerPartAsset : ScriptableObject
{
    public CharacterPartAsset CharacterPart;

    [SerializeField]
    public string Id = Guid.NewGuid().ToString();


    //This will be used in the future for class specific items.
    [SerializeField]
    private CharacterClass _characterClass = CharacterClass.Arcanum;


    [Flags]
    public enum CharacterClass
    {
        None = 0,
        Marksman = 1,
        Arcanum = 2,
        Mysterite = 3,
    }

}