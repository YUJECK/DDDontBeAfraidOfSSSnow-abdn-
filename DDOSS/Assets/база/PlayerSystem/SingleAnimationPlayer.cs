using UnityEngine;

namespace база.PlayerSystem
{
    public sealed class SingleAnimationPlayer : MonoBehaviour
    {
        [SerializeField] private string animationToPlay;
        [SerializeField] private Animator animator;

        private void Start()
        {
            if(animator == null)
                animator = GetComponent<Animator>();
        }

        public void Play()
        {
            animator.Play(animationToPlay);
        }
    }
}