using System.Collections;
using UnityEngine;
using VContainer;
using база.InputServices;
using база.InventorySystem;
using база.PlayerSystem;
using база.PlayerSystem.PlayerECS;

namespace база.Tests
{
    public class CristalMinerAndObject : MonoBehaviour, IExaminable
    {
        [SerializeField] private Item item;
        
        private Player _player;
        private Inventory _inventory;
        private IObjectResolver _resolver;
        private IInputService _inputService;

        private Coroutine _mineCoroutine;

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
            GetComponent<SpriteRenderer>().sprite = item.ItemWorldImage;
        }

        private void Update()
        {
            if(item != null)
                item.OnInWorld(gameObject);
        }

        public void Examine()
        {
            if(_mineCoroutine != null)
                return;
            
            _mineCoroutine = StartCoroutine(Mine());
        }

        private IEnumerator Mine()
        {
            _player.Animator.Play("PlayerMine");

            _inputService.DisablePlayerInputs();
            
            yield return new WaitForSeconds(1.1f);
            
            _inputService.EnablePlayerInputs();

            _player.Animator.Play("PlayerIdle");
            _inventory.Add(item);
            item.OnRemovedFromGameObject(gameObject);
            Destroy(gameObject);
        }
    }
}