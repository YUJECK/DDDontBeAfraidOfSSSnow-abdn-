using UnityEngine;
using UnityEngine.UI;

namespace база.InventorySystem
{
    public class InventorySlot : MonoBehaviour
    {
        public Item Item { get; private set; }
        public bool NotEmpty => Item != null;
        public bool Empty => Item == null;

        private Image _image;

        private void Start()
        {
            _image = GetComponentInChildren<Image>();
            
            SetItem(null);
        }

        public void SetItem(Item item)
        {
            Item = item;
            
            if (item == null)
            {
                _image.color = Color.clear;
                return;
            }

            _image.color = Color.white;
            _image.sprite = item.ItemImage;
        }
    }
}