using System;
using System.Collections.Generic;
using System.Linq;
using VContainer.Unity;

namespace база.InventorySystem
{
    public sealed class Inventory : ITickable
    {
        private readonly Dictionary<Type, List<Item>> _items = new();
        public const int InventorySize = 10;

        public bool IsFull => ItemsCount() >= InventorySize;
        public int ItemsCount()
        {
            int count = 0;

            foreach (var itemContainer in _items)
            {
                count += itemContainer.Value.Count;
            }

            return count;
        }

        public event Action<Item> OnAdded; 
        public event Action<Item> OnRemoved;

        public Item[] GetAll()
        {
            var allItems = new List<Item>();

            foreach(var itemPair in _items)
            {
                allItems.AddRange(itemPair.Value);
            }

            return allItems.ToArray();
        }

        public bool Contains<TItem>()
        {
            return _items.ContainsKey(typeof(TItem));
        }
        
        public void Add(Item item)
        {
            if (item == null || ItemsCount() >= InventorySize)
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

            foreach (Item item1 in _items[type].GetRange(0, count)) 
                item1.OnRemovedFromInventory(this);
            
            _items[type].RemoveRange(0, count);

            OnRemoved?.Invoke(item);
        }

        public void Remove(Item item, int count)
        {
            if(!_items.ContainsKey(item.GetItemType()))
                return;
            
            foreach (Item item1 in _items[item.GetItemType()].GetRange(0, count)) 
                item1.OnRemovedFromInventory(this);
            _items[item.GetItemType()].RemoveRange(0, count);
            
            OnRemoved?.Invoke(item);
        }

        public void Remove(Item item)
        {
            _items[item.GetItemType()].Remove(item);
            item.OnRemovedFromInventory(this);
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
