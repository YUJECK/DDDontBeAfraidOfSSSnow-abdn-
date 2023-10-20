using UnityEngine;
using VContainer;
using база.InputServices;
using база.Player.PlayerECS;

namespace база.Player
{
    public sealed class Examiner : DefaultusComponent
    {
        private IInputService _inputService;
        private readonly RaycastHit2D[] _raycasted = new RaycastHit2D[20];
        private const float ExamineDistance = 4f;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        public override void OnAdded()
        {
            _inputService.OnExamine += OnExamine;
        }

        private void OnExamine()
        {
            var size = Physics2D.RaycastNonAlloc(_inputService.MousePosition, Vector2.zero, _raycasted);

            for (int i = 0; i < size; i++)
            {
                var current = _raycasted[i];

                if (current.transform.gameObject.TryGetComponent<IExaminable>(out var examinable) &&
                    Vector3.Distance(current.transform.position, Master.transform.position) <= ExamineDistance)
                {
                    examinable.Examine();
                }
            }
        }
    }
}