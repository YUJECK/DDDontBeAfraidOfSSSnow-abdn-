using UnityEngine;

namespace база.MOBS.TargetSystem
{
    public sealed class EnemiesMovePoints
    {
        private Target[] _targets;

        public EnemiesMovePoints(Target[] targets)
        {
            _targets = targets;
        }

        public Target GetRandom()
        {
            var random = _targets[Random.Range(0, _targets.Length)];
        
            if (random.CurrentTargetables.Count > 0)
                return GetRandom();

            return random;
        }
    }
}