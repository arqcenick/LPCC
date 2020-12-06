using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public class CoroutineQueue : MonoBehaviour
    {

        public static CoroutineQueue Instance;
    
        private Queue<IEnumerator> _coroutineQueue = new Queue<IEnumerator>();
    
        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            StartCoroutine(RunCoroutines());
        }

        public void Enqueue(IEnumerator coroutine)
        {
            _coroutineQueue.Enqueue(coroutine);
        }
    
        public IEnumerator RunCoroutines()
        {
            while (true)
            {
                while (_coroutineQueue.Count > 0)
                {
                    yield return StartCoroutine(_coroutineQueue.Dequeue());
                }

                yield return null;
            }
        }
    
    }
}
