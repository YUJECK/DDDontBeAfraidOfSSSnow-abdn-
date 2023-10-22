using UnityEngine;
using база.InventorySystem;
using база.PlayerSystem.PlayerECS;

namespace база.Tests
{
    public class CristalWorldObject : MonoBehaviour
    {
        [SerializeField] private Item item;
        
        private Player _player;
        private Inventory _inventory;

        private void Construct(Player player, Inventory inventory)
        {
            _player = player;
            _inventory = inventory;
        }
        
        
    }
}