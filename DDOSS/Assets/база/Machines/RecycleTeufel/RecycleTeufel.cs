using VContainer;
using база.InventorySystem;
using база.Recyclables;

namespace база.Machines.RecycleTeufel
{
    public sealed class RecycleTeufel : Machine<IRecyclable>
    {
        [Inject]
        private void Construct(Inventory inventory)
        {
            SetInventory(inventory);
        }
        
        protected override void OnProcessTypedItem(Item item, IRecyclable typedItem)
        {
            Inventory.Remove(item);
            Inventory.Add(typedItem.Recycle());
        }
    }
}