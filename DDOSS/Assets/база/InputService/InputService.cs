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
        public event Action OnExamine;
        public Vector2 MousePosition { get; private set; }

        private Vector2 _movement;  
        
        private readonly Inputs _inputs;

        public InputService()
        {
            _inputs = new Inputs();

            _inputs.Player.Movement.performed += OnMoving;
            _inputs.Player.Examine.performed += Examine;
            
            _inputs.Enable();
        }

        private void Examine(InputAction.CallbackContext obj)
        {
            OnExamine?.Invoke();
        }

        private void OnMoving(InputAction.CallbackContext obj)
        {
            _movement = obj.ReadValue<Vector2>();
        }

        public void Tick()
        {
            OnMoved?.Invoke(ReadMovement());
            MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        private Vector2 ReadMovement()
            => _inputs.Player.Movement.ReadValue<Vector2>();
    }
}