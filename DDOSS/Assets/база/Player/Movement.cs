using UnityEngine;
using VContainer;
using база.InputServices;
using база.Player.PlayerECS;

namespace база.Player
{
    public sealed class Movement : DefaultusComponentus
    {
        private IInputService _inputService;
        
        public Vector2 CurrentMovement { get; private set; }

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        public override void OnAdded()
        {
            base.OnAdded();
            
            _inputService.OnMoved += OnMoved;
        }

        public override void OnRemoved()
        {
            _inputService.OnMoved -= OnMoved;
        }

        private void OnMoved(Vector2 movement)
        {
            CurrentMovement = movement * 5;
            
            Master.Rigidbody2D.velocity = CurrentMovement;
        }
    }
}