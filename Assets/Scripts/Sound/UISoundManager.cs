using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISoundManager : MonoBehaviour
{

    [SerializeField] private AudioClip _buttonHoverClip;

    private AudioSource _buttonHover;
    void Awake()
    {
        UIEventSingleton<OnButtonHovered>.Instance.AddListener(PlayButtonHovered);
    }

    private void PlayButtonHovered()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
