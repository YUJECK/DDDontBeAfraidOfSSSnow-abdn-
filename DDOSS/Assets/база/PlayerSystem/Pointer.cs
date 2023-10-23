using UnityEngine;
using VContainer;
using база.InputServices;
using база.PlayerSystem.PlayerECS;

namespace база.PlayerSystem
{
    public sealed class Pointer : DefaultusComponentus
    {
        private IInputService _inputService;
        private IPointable _lastPointable;
        private GameObject _lastPointableGameObject;

        public const float ExamineDistance = 2f;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        public override void OnUpdate()
        {
            var hit = Physics2D.Raycast(_inputService.MousePosition, Vector2.zero);

            if (hit.transform != null)
            {
                if (hit.transform.gameObject != _lastPointableGameObject && _lastPointableGameObject != null)
                    _lastPointable.Unpoint();
                
                if (hit.transform.gameObject.TryGetComponent<IPointable>(out var pointable) && CheckDistance(hit.transform.position))
                {
                    pointable.Point();
                    _lastPointable = pointable;
                    _lastPointableGameObject = hit.transform.gameObject;
                }
            }
            else if(_lastPointableGameObject != null)
            {
                _lastPointable.Unpoint();
            }
        }

        private bool CheckDistance(Vector3 toCheck) => Vector3.Distance(toCheck, Master.transform.position) <= ExamineDistance;
    }
}