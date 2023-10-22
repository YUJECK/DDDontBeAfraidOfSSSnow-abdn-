using UnityEngine;
using UnityEngine.UI;
using VContainer;
using база.PlayerSystem.PlayerECS;

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
        private Player _player;

        [Inject]
        private void Construct(Inventory inventory, ItemsDropper dropper, Player player)
        {
            _inventory = inventory;
            _dropper = dropper;
            _player = player;
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
                _dropper.Spawn(item, GetPos() );
            }
        }

        private Vector2 GetPos()
        {
            return new(_player.transform.position.x - _player.transform.localScale.x, _player.transform.position.y);
        }
    }
}
