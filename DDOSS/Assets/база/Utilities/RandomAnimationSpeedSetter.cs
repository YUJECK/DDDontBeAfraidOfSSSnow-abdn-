using UnityEngine;
using Random = UnityEngine.Random;

namespace база.Utilities
{
    [RequireComponent(typeof(Animator))]
    public class RandomAnimationSpeedSetter : MonoBehaviour
    {
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _animator.speed = Random.Range(0.5f, 1.5f);
        }
    }
}
