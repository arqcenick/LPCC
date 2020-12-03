using System;
using UnityEngine;

namespace UI
{
    public class CameraStateController : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
               UIEventSingleton<OnOverviewMenuSelected>.Instance.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                UIEventSingleton<OnHeroMenuSelected>.Instance.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                UIEventSingleton<OnItemMenuSelected>.Instance.Invoke();
            }
        }
    }
}
