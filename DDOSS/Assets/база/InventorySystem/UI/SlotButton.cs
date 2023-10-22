using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace база.InventorySystem.UI
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(InventorySlot))]
    public class SlotButton : MonoBehaviour
    {
        private Button _button;
        private InventorySlot _slot;
        private Inventory _inventory;
        private ItemsDropper _dropper;

        [Inject]
        private void Construct(Inventory inventory, ItemsDropper dropper)
        {
            _inventory = inventory;
            _dropper = dropper;
        }
        
        private void Start()
        {
            _slot = GetComponent<InventorySlot>();
            _button = GetComponent<Button>();
            
            _button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            if (_slot.Item != null)
            {
                var item = _slot.Item;
                
                _inventory.Remove(_slot.Item);
                _dropper.Spawn(item, Vector2.zero);
            }
        }
    }
}
