using System;
using UnityEngine;
using VContainer.Unity;

namespace база.InputService
{
    public sealed class InputService : IInputService, ITickable 
    {
        public event Action<Vector2> OnMoved;

        public void Tick()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            
            OnMoved?.Invoke(new Vector2(horizontal, vertical));
        }
    }
}