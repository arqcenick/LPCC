using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// A singleton sound manager
/// </summary>
public class UISoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource _buttonHover;

    [SerializeField]
    private AudioSource _buttonClick;

    void Awake()
    {
        UIEventSingleton<OnButtonHovered>.Instance.AddListener(PlayButtonHovered);
        UIEventSingleton<OnButtonClicked>.Instance.AddListener(PlayButtonClicked);

    }

    private void PlayButtonClicked()
    {
        _buttonClick.Play();
    }

    private void PlayButtonHovered()
    {
        _buttonHover.Play();
    }
    
}
