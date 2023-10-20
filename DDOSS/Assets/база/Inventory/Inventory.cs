using System;
using System.Collections.Generic;
using VContainer.Unity;

namespace база.InventorySystem
{
    public sealed class Inventory : ITickable
    {
        private readonly Dictionary<Type, List<Item>> _items = new();
        
        public void Add(Item item)
        {
            if (item == null)
                return;
            
            if (!_items.ContainsKey(item.GetItemType()))
            {
                _items.Add(item.GetItemType(), new List<Item>() { item });
            }
            else
            {
                _items[item.GetItemType()].Add(item);
            }
            
            item.OnAddedToInventory(this);
        }

        public void Remove(Type type, int count)
        {
            _items[type].RemoveRange(0, count);
        }

        public void Remove(Item item, int count)
        {
            _items[item.GetItemType()].RemoveRange(0, count);
        }

        public void Remove(Item item)
        {
            _items[item.GetItemType()].Remove(item);
        }
        
        public void Tick()
        {
            foreach (var itemList in _items)
            {
                foreach (var item in itemList.Value)
                    item.OnInInventory(this);
            }
        }
    }
}