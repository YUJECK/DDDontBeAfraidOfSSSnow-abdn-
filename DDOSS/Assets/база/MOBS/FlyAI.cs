using UnityEngine;
using VContainer;
using база.InventorySystem;
using база.MOBS.TargetSystem;
using база.PlayerSystem;
using база.Tests;

namespace база.MOBS
{
    public class FlyAI : MonoBehaviour, ITargetable
    {
        private EnemiesMovePoints _enemiesMovePoints;
        private Inventory _inventory;
        public Target CurrentTarget { get; private set; }

        [Inject]
        private void Construct(EnemiesMovePoints enemiesMovePoints, Inventory inventory)
        {
            _enemiesMovePoints = enemiesMovePoints;
            _inventory = inventory;
        }

        private void Start()
        {
            CurrentTarget = _enemiesMovePoints.GetRandom();
        }

        private void Update()
        {
            if (CurrentTarget != null)
                transform.position = Vector3.MoveTowards(transform.position, CurrentTarget.transform.position,
                    Time.deltaTime * 3);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerTarget target) && _inventory.Contains<TestItem>())
            {
                CurrentTarget = target;
                CurrentTarget.OnTargeted(this);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out PlayerTarget target) && target == CurrentTarget)
            {
                CurrentTarget = _enemiesMovePoints.GetRandom();
                CurrentTarget.OnTargeted(this);
            }
        }
    }
}