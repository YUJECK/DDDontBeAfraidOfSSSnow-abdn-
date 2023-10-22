using UnityEngine;
using VContainer;
using база.InputServices;
using база.PlayerSystem.PlayerECS;

namespace база.PlayerSystem
{
    public sealed class Movement : DefaultusComponentus
    {
        private IInputService _inputService;
        private static readonly int AnimatorMovement = Animator.StringToHash("Movement");

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
            Master.Animator.SetBool(AnimatorMovement, CurrentMovement != Vector2.zero);
        }
    }
}