using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;
using база.InputServices;
using база.InventorySystem;
using база.PlayerSystem.PlayerECS;

namespace база.Tests
{
    public class ItemPicker : MonoBehaviour, IExaminable
    {
        public Item item;
    
        private Inventory _inventory;
        private IObjectResolver _resolver;
        private IInputService _inputService;
        private Player _player;

        [Inject]
        private void Construct(Inventory inventory, IObjectResolver resolver, IInputService inputService, Player player)
        {
            _inventory = inventory;
            _resolver = resolver;
            _inputService = inputService;
            _player = player;
        }

        private void Awake()
        {
            if (item != null)
                SetItem(Instantiate(item));
        }

        public void SetItem(Item newItem)   
        {
            item = newItem;
            
            _resolver.Inject(item);
            item.OnSpawnedInWorld(gameObject);
            GetComponent<SpriteRenderer>().sprite = item.ItemImage;
        }

        private void Update()
        {
            if(item != null)
                item.OnInWorld(gameObject);
        }

        public async void Examine()
        {  
            _player.Animator.Play("PlayerPickUp");

            _inputService.DisablePlayerInputs();
            
            await UniTask.WaitForSeconds(0.5f);
            
            _inputService.EnablePlayerInputs();

            _player.Animator.Play("PlayerIdle");
            _inventory.Add(item);
            item.OnRemovedFromGameObject(gameObject);
            Destroy(gameObject);
        }
    }
}
