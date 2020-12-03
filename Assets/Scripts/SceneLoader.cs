using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] 
    private Animator _animator;
    void Awake()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive).completed  += operation =>
        {
            GameObject.FindWithTag("CharacterCamera").GetComponent<CinemachineStateDrivenCamera>().m_AnimatedTarget =
                _animator;
        };
    }


}
