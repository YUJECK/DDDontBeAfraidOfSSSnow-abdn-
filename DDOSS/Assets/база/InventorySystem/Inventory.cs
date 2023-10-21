using System;
using System.Collections.Generic;
using System.Linq;
using VContainer.Unity;

namespace база.InventorySystem
{
    public sealed class Inventory : ITickable
    {
        private readonly Dictionary<Type, List<Item>> _items = new();

        public event Action<Item> OnAdded; 
        public event Action<Item> OnRemoved; 
        
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
            OnAdded?.Invoke(item);
        }

        public void Remove(Type type, int count)
        {
            if(!_items.ContainsKey(type))
                return;

            var item = _items[type].First();
            
            _items[type].RemoveRange(0, count);
            OnRemoved?.Invoke(item);
        }

        public void Remove(Item item, int count)
        {
            if(!_items.ContainsKey(item.GetItemType()))
                return;
            
            _items[item.GetItemType()].RemoveRange(0, count);
            
            OnRemoved?.Invoke(item);
        }

        public void Remove(Item item)
        {
            _items[item.GetItemType()].Remove(item);
            OnRemoved?.Invoke(item);
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