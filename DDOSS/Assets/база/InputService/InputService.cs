using System;
using DDOSS.InputsServices;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer.Unity;

namespace база.InputServices
{
    public sealed class InputService : IInputService, ITickable 
    {
        public event Action<Vector2> OnMoved;

        private Vector2 _movement;  
        private readonly Inputs _inputs;

        public InputService()
        {
            _inputs = new Inputs();

            _inputs.Player.Movement.performed += OnMoving;
            _inputs.Enable();
        }

        private void OnMoving(InputAction.CallbackContext obj)
        {
            _movement = obj.ReadValue<Vector2>();
        }

        public void Tick()
        {
            OnMoved?.Invoke(ReadMovement());
        }

        private Vector2 ReadMovement()
            => _inputs.Player.Movement.ReadValue<Vector2>();
    }
}