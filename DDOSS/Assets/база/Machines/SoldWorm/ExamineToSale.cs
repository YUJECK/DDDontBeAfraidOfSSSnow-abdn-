using UnityEngine;
using VContainer;
using база.Economy;
using база.InventorySystem;

namespace база.Machines
{
    [RequireComponent(typeof(Animator))]
    public sealed class ExamineToSale : Machine<ISellable>
    {
        public AudioSource saleSource;
        
        private Wallet _wallet;
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        [Inject]
        private void Construct(Inventory inventory, Wallet wallet)
        {
            SetInventory(inventory);
            _wallet = wallet;
        }

        protected override void OnProcessTypedItem(Item item, ISellable typedItem)
        {
            _wallet.AddMoney(typedItem.Price);
            Inventory.Remove(item);
            saleSource.Play();
        }

        protected override void OnCompletedWithItems()
        {
            _animator.Play("SoldingWormOnSold");
        }
    }
}
