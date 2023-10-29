using UnityEngine;
using база.InventorySystem;
using база.PlayerSystem;

namespace база.Machines
{
    public abstract class Machine<TItem> : MonoBehaviour, IExaminable
    {
        protected Inventory Inventory { get; private set; }

        protected void SetInventory(Inventory inventory) => Inventory = inventory;
        
        protected virtual void OnStartedProcessing(Item[] items) {}
        protected virtual void OnStartedProcessing() {}
        protected virtual void OnProcessAnyItem(Item item) { }
        protected virtual void OnProcessTypedItem(Item item, TItem typedItem) { }
        protected virtual void OnCompleted() { }
        protected virtual void OnCompletedWithItems() { }
        protected virtual void OnCompletedWithoutItems() { }

        public void Examine()
        {
            var allItems = Inventory.GetAll();
            
            OnStartedProcessing(allItems);
            OnStartedProcessing();

            bool containsNeededItems = false;

            foreach (var item in allItems)
            {
                if (item is TItem typedItem)
                {
                    OnProcessTypedItem(item, typedItem);
                    containsNeededItems = true;
                }
                
                OnProcessAnyItem(item);
            }

            OnCompleted();

            if (containsNeededItems)
            {
                OnCompletedWithItems();
            }
            else
            {
                OnCompletedWithoutItems();
            }
        }
    }
}