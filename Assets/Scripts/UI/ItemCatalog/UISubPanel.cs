using System;
using CharacterCustomizer;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace UI.ItemCatalog
{
    public class UISubPanel : MonoBehaviour
    {
        [SerializeField] 
        private bool _isAlternative;
        private CanvasGroup _canvasGroup;
        [SerializeField] 
        private TextMeshProUGUI _titleText;
        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            UIEventSingleton<OnItemTypeSelected, CharacterPart>.Instance.AddListener(OnCharacterPartSelected);
        }

        private void OnCharacterPartSelected(CharacterPart characterPart)
        {
            bool isActive = !_isAlternative || UIAlternativeConverter.GetAlternativePart(characterPart) != CharacterPart.Invalid;
            gameObject.SetActive(isActive);
            if (isActive)
            {
                _canvasGroup.DOFade(1, 0.2f);
                string text = "INVALID_TEXT";
                if (_isAlternative)
                {
                    characterPart = UIAlternativeConverter.GetAlternativePart(characterPart);
                }
                switch (characterPart)
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
                        text = "Head";
                        break;
                    case CharacterPart.Pants:
                        text = "Pants";
                        break;
                    case CharacterPart.Torso:
                        text = "Torso Armor";
                        break;
                    case CharacterPart.Shoe:
                        text = "Shoes";

                        break;
                    case CharacterPart.Glove:
                        text = "Gloves";
                        break;
                    case CharacterPart.Belt:
                        break;
                    case CharacterPart.RobeShort:
                        text = "Bottom Armor";
                        break;
                    case CharacterPart.RobeLong:
                        break;
                    case CharacterPart.EndOfSkins:
                        break;
                    case CharacterPart.Helmet:
                        text = "Head Gear";
                        break;
                    case CharacterPart.ShoulderArmor:
                        text = "Shoulder Armor";
                        break;
                    case CharacterPart.TorsoArmor:
                        text = "Torso Addon";
                        break;
                    case CharacterPart.BottomArmor:
                        break;
                    case CharacterPart.Weapon1:
                        text = "Ranged Weapon";
                        break;
                    case CharacterPart.Weapon2:
                        text = "Melee Weapon";
                        break;
                    case CharacterPart.Invalid:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(characterPart), characterPart, null);
                }

                _titleText.text = text;

            }
            else
            {
                _canvasGroup.alpha = 0;
            }
        }
    }
}