using System;
using UnityEngine;

namespace база.WorldBase
{
    public interface IDestroyable
    {
        public GameObject Instance { get; }
        
        public event Action OnDestroyed;
    }
}