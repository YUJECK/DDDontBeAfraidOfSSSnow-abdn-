using System;
using UnityEngine;
using база.InventorySystem;
using база.WorldBase;

namespace база.Crystales
{
    public class WorldCrystal : MonoBehaviour, IDestroyable
    {
        public Item item;
        
        public GameObject Instance => gameObject;
        public event Action OnDestroyed;

        public void OnDestroy()
        {
            OnDestroyed?.Invoke();
        }
    }
}