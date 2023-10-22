using Unity.Mathematics;
using UnityEngine;
using VContainer;
using база.Tests;

namespace база.InventorySystem.UI
{
    public sealed class ItemsDropper
    {
        private ItemPicker _itemPickerPrefab;
        private readonly IObjectResolver _resolver;

        public ItemsDropper(ItemPicker itemPickerPrefab, IObjectResolver resolver)
        {
            _itemPickerPrefab = itemPickerPrefab;
            _resolver = resolver;
        }

        public void Spawn(Item item, Vector2 position)
        {
            var picker = GameObject.Instantiate(_itemPickerPrefab, position, quaternion.identity);
            _resolver.Inject(picker);
            
            picker.SetItem(item);
        }
    }
}