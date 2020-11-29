using UnityEngine.Events;

namespace CharacterCustomizer
{
    public class GameEvent<T,U> where T : UnityEvent<U>, new()
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
}