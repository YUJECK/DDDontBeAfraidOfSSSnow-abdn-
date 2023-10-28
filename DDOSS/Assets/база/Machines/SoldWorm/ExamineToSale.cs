using UnityEngine;
using VContainer;
using база.Economy;
using база.InventorySystem;
using база.PlayerSystem;

namespace база.Machines
{
    [RequireComponent(typeof(Animator))]
    public sealed class ExamineToSale : MonoBehaviour, IExaminable
    {
        public AudioSource saleSource;

        private Inventory _inventory;
        private Wallet _wallet;

        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        [Inject]
        private void Construct(Inventory inventory, Wallet wallet)
        {
            _inventory = inventory;
            _wallet = wallet;
        }

        public void Examine()
        {
            var allItems = _inventory.GetAll();

            bool solded = false;
            
            foreach(var item in allItems)
            {
                if(item is ISellable sellableItem)
                {
                    _wallet.AddMoney(sellableItem.Price);
                    _inventory.Remove(item);
                    saleSource.Play();

                    solded = true;
                }
            }
            
            if(solded)
                _animator.Play("SoldingWormOnSold");
        }
    }
}
