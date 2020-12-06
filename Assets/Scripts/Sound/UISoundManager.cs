using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource _buttonHover;
    void Awake()
    {
        UIEventSingleton<OnButtonHovered>.Instance.AddListener(PlayButtonHovered);
    }

    private void PlayButtonHovered()
    {
        Debug.Log("Playing sound");
        _buttonHover.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
