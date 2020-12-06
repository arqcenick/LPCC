using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SetTextureOnLoad : MonoBehaviour
{
    [SerializeField] private RenderTexture _texture;

    private void Awake()
    {
        var brain = GetComponent<Camera>();
        brain.targetTexture = _texture;
    }
}
