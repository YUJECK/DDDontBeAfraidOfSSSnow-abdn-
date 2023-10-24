using UnityEngine;
using VContainer;
using база.Economy;
using база.InventorySystem;

namespace база.Machines
{
    public sealed class ExamineToSale : MonoBehaviour, IExaminable
    {
        public AudioSource saleSource;

        private Inventory _inventory;
        private Wallet _wallet;

        [Inject]
        private void Construct(Inventory inventory, Wallet wallet)
        {
            _inventory = inventory;
            _wallet = wallet;
        }

        public void Examine()
        {
            var allItems = _inventory.GetAll();

            foreach(var item in allItems)
            {
                if(item is ISellable sellableItem)
                {
                    _wallet.AddMoney(sellableItem.Price);
                    _inventory.Remove(item);
                    saleSource.Play();
                }
            }
        }
    }
}
