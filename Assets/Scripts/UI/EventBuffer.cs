using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// Event buffer makes it possible to listen for events and return as bool for the state machine.
    /// </summary>
    public static class EventBuffer
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        static void Init()
        {
            _subscribedEvents = new Dictionary<Type, bool>();
        }
        
        private static Dictionary<Type, bool> _subscribedEvents = new Dictionary<Type, bool>();
        
        public static bool IsTriggerSet<T>() where T : UIEvent, new()
        {
            if (!_subscribedEvents.ContainsKey(typeof(T)))
            {
                UIEventSingleton<T>.Instance.AddListener(() =>
                {
                    _subscribedEvents[typeof(T)] = true;
                });
                _subscribedEvents[typeof(T)] = false;
                return false;

            }
            if (_subscribedEvents[typeof(T)])
            {
                _subscribedEvents[typeof(T)] = false;
                return true;
            }

            return false;
        }

        public static void Clear()
        {
            foreach (var key in _subscribedEvents.Keys.ToList())
            {
                _subscribedEvents[key] = false;
            }
        }
    }
}