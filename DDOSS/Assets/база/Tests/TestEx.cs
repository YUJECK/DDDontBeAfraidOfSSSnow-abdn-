using System;
using UnityEngine;
using VContainer;
using база.InventorySystem;

public class TestEx : MonoBehaviour, IExaminable
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
        _resolver.Inject(item);
        item.OnSpawnedInWorld(gameObject);
    }

    private void Update()
    {
        item.OnInWorld(gameObject);
    }

    public void Examine()
    {   
        _inventory.Add(item);
        
        item.OnRemovedFromGameObject(gameObject);
        Destroy(gameObject);
    }
}
