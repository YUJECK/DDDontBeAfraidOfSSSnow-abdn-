using UnityEngine;
using VContainer;
using база.InputServices;
using база.Player.PlayerECS;

namespace база.Player
{
    public sealed class Pointer : DefaultusComponentus
    {
        private IInputService _inputService;
        private RaycastHit2D[] _raycasted = new RaycastHit2D[10];
        
        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }
        
        public override void OnUpdate()
        {
            var size = Physics2D.RaycastNonAlloc(_inputService.MousePosition, Vector2.zero, _raycasted);

            for (int i = 0; i < size; i++)
            {
                var current = _raycasted[i];

                if (current.transform.gameObject.TryGetComponent<IPointable>(out var pointable))
                {
                    pointable.Point();
                }
            }
        }
    }
}