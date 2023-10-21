using System;
using UnityEngine;
using UnityEngine.UI;

namespace база.InventorySystem
{
    public abstract class Item : ScriptableObject
    {
        [field: SerializeField] public Sprite ItemImage { get; private set; }
        [field: SerializeField] public Sprite ItemWorldImage { get; private set; }
        [field: SerializeField] public string ItemID { get; private set; }

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