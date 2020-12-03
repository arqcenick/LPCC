using System;
using System.Collections;
using System.Collections.Generic;
using CharacterCustomizer;
using UnityEngine;

public class ItemCameraStateController : MonoBehaviour
{
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        UIEventSingleton<OnItemTypeSelected, CharacterPart>.Instance.AddListener(OnItemTypeSelected);
    }

    private void OnItemTypeSelected(CharacterPart part)
    {
        switch (part)
        {
            case CharacterPart.Skin:
                break;
            case CharacterPart.Eye:
                break;
            case CharacterPart.Eyebrow:
                break;
            case CharacterPart.Beard:
                break;
            case CharacterPart.Hair:
                break;
            case CharacterPart.Scar:
                break;
            case CharacterPart.FaceFeature:
                break;
            case CharacterPart.Head:
                break;
            case CharacterPart.Pants:
                _animator.Play("Pants");
                break;
            case CharacterPart.Torso:
                _animator.Play("Torso");
                break;
            case CharacterPart.Shoe:
                break;
            case CharacterPart.Glove:
                _animator.Play("Gloves");
                break;
            case CharacterPart.Belt:
                break;
            case CharacterPart.RobeLong:
                break;
            case CharacterPart.EndOfSkins:
                break;
            case CharacterPart.Helmet:
                break;
            case CharacterPart.ShoulderArmor:
                break;
            case CharacterPart.TorsoArmor:
                break;
            case CharacterPart.BottomArmor:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(part), part, null);
        }
    }
}
