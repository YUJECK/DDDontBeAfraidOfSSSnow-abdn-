using UnityEngine;
using база.Economy;
using база.InventorySystem;

namespace база.Tests
{
    [CreateAssetMenu(menuName = "Items/Ruby")]
    public sealed class Ruby : Item, ISellable
    {
        [field: SerializeField] public int Price { get; private set; } = 15;
    }
}