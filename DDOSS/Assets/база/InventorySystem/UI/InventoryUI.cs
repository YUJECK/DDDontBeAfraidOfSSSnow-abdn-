using System.Collections.Generic;
using UnityEngine;
using VContainer;
using база.WorldBase;

namespace база.InventorySystem.UI
{
    public sealed class InventoryUI : MonoBehaviour
    {
        [SerializeField] private GameObject inventoryFullLabel;
        private List<InventorySlot> _slots = new();

        private Inventory _inventory;

        [Inject]
        private void Construct(Inventory inventory, IObjectResolver resolver)
        {
            Injector.SetResolver(resolver);
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

            CheckIsFull();
        }

        private void OnRemoved(Item item)
        {
            Find(item.ItemID).SetItem(null);
            CheckIsFull();
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

        private void CheckIsFull()
        {
            if (_inventory.IsFull) inventoryFullLabel.SetActive(true);
            else inventoryFullLabel.SetActive(false);
        }
    }
}
