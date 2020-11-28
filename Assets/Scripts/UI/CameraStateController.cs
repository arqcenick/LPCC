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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Face"))
                {
                    _animator.Play("FullBody");
                }
                else if (_animator.GetCurrentAnimatorStateInfo(0).IsName("FullBody"))
                {
                    _animator.Play("Face");
                }
            }
        }
    }
}
