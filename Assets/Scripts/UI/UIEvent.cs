
using CharacterCustomizer;
using UnityEngine.Events;

public class UIEvent<T,U> where T : UnityEvent<U>, new()
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null) _instance = new T();

            return _instance;
        }
    }
}

public class OnItemTypeSelected : UnityEvent<CharacterPart>
{
    
}