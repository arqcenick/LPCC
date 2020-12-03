
using CharacterCustomizer;
using UnityEngine.Events;

public class UIEventSingleton<T,U> where T : UIEvent<U>, new()
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

public class UIEventSingleton<T> where T : UIEvent, new()
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

public abstract class UIEvent<T> : UnityEvent<T> { }
public abstract class UIEvent : UnityEvent { }

public class OnItemTypeSelected : UIEvent<CharacterPart>{}

public class OnOverviewMenuSelected : UIEvent{}
public class OnItemMenuSelected : UIEvent{}
public class OnHeroMenuSelected : UIEvent{}

public class OnCharacterPartSelected : UIEvent<int>{}

public class OnCharacterSelected : UIEvent<PlayerPartAsset.CharacterClass>{}
