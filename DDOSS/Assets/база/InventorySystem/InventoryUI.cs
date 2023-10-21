using System.Collections.Generic;
using UnityEngine;
using VContainer;
using база.InventorySystem;

namespace база.InventorySystem
{
    public sealed class InventoryUI : MonoBehaviour
    {
        private List<InventorySlot> _slots = new();

        private InventorySystem.Inventory _inventory;

        [Inject]
        private void Construct(InventorySystem.Inventory inventory)
        {
            _inventory = inventory;
        }
    
        private void Awake()
        {
            _slots = new List<InventorySlot>(GetComponentsInChildren<InventorySlot>());
        }

        private void OnEnable()
        {
            _inventory.OnAdded += OnAdded;
            _inventory.OnRemoved += OnRemoved;
        }

        private void OnAdded(Item item)
        {
            FindNull().SetItem(item);
        }

        private void OnRemoved(Item item)
        {
            Find(item.ItemID).SetItem(null);
        }

        private InventorySlot Find(string itemID)
        {
            foreach (var slot in _slots)
            {
                if (slot.NotEmpty && slot.Item.ItemID == itemID)
                    return slot;
            }

            return null;
        }

        private InventorySlot FindNull()
        {
            foreach (var slot in _slots)
            {
                if (slot.Empty)
                    return slot;
            }

            return null;
        }
    }
}
