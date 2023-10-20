using UnityEngine;
using VContainer;
using база.InputServices;
using база.InventorySystem;

namespace база.Tests
{
    [CreateAssetMenu(menuName = "Items/Test")]
    public sealed class TestItem : Item
    {
        [Inject]
        private void Construct(IInputService inputService)
        {
            Debug.Log(inputService.GetType());
        }

        public override void OnSpawnedInWorld(GameObject master)
        {
            Debug.Log(master.name);   
        }

        public override void OnInWorld(GameObject master)
        {
            Debug.Log(master.name);
        }

        public override void OnRemovedFromGameObject(GameObject master)
        {
            Debug.Log(master.name);
        }

        public override void OnAddedToInventory(Inventory inventory)
        {
            Debug.Log(inventory.GetType());
        }

        public override void OnRemovedFromInventory(Inventory inventory)
        {
            Debug.Log(inventory.GetType());
        }

        public override void OnInInventory(Inventory inventory)
        {
            Debug.Log(inventory.GetType());
        }
    }
}