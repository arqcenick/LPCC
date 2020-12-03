using UnityEngine.Events;

namespace CharacterCustomizer
{
    public class GameEventSingleton<T,U> where T : GameEvent<U>, new()
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


    public abstract class GameEvent<T> : UnityEvent<T> { }
    public class OnCharacterModelDataUpdated : GameEvent<CharacterData> {}
    public class OnCharacterSkinModified : GameEvent<CharacterSkinAsset>{}
}