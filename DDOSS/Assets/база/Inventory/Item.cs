using System;
using UnityEngine;

namespace база.InventorySystem
{
    public abstract class Item : ScriptableObject
    {
        public virtual Type GetItemType()
            => this.GetType();


        public virtual void OnSpawnedInWorld(GameObject master)
        {
            
        }

        public virtual void OnRemovedFromGameObject(GameObject master)
        {
            
        }

        public virtual void OnInWorld(GameObject master)
        {
            
        }

        public virtual void OnAddedToInventory(Inventory inventory)
        {
            
        }
        
        public virtual void OnRemovedFromInventory(Inventory inventory)
        {
            
        }
        
        public virtual void OnInInventory(Inventory inventory)
        {
            
        }
    }
}