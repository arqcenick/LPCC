using System;
using UnityEngine;

namespace CharacterCustomizer
{
    public class MeshItem : MonoBehaviour
    {
        public CharacterItemPart ItemPart => _itemPart;

        [SerializeField]
        private CharacterItemPart _itemPart;

        private GameObject _children;
        
        public void SetItem(CharacterItemAsset item)
        {
            if (_children != null)
            {
                Destroy(_children);
            }
            _children = Instantiate(item.ItemPrefab, transform);
        }
    }
}