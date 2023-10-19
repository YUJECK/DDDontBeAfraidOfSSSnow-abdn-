using UnityEngine;
using VContainer;
using VContainer.Unity;
using база.InputServices;
using база.Player.PlayerECS;

namespace база.Player
{
    public sealed class Movement : DefaultusComponent
    {
        private IInputService _inputService;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
            _inputService.OnMoved += OnMoved;
        }

        
        
        private void OnMoved(Vector2 movement)
        {
            Master.Rigidbody2D.velocity = movement * 5;
        }
    }
}