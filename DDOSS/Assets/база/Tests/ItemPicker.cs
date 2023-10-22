using UnityEngine;
using VContainer;
using база.InventorySystem;

namespace база.Tests
{
    public class ItemPicker : MonoBehaviour, IExaminable
    {
        public Item item;
    
        private Inventory _inventory;
        private IObjectResolver _resolver;

        [Inject]
        private void Construct(Inventory inventory, IObjectResolver resolver)
        {
            _inventory = inventory;
            _resolver = resolver;
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
            _inventory.Add(item);
        
            item.OnRemovedFromGameObject(gameObject);
            Destroy(gameObject);
        }
    }
}
