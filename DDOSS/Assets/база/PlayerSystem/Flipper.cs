using UnityEngine;
using база.PlayerSystem.PlayerECS;

namespace база.PlayerSystem
{
    public sealed class Flipper : DefaultusComponentus
    {
        private readonly Movement _movement;
            public FacingDirections FacingDirection { get; private set; }

        public Flipper(Movement movement)
        {
            _movement = movement;
        }

        public override void OnUpdate()
        {
            Face();
        }

        public void Flip(FacingDirections facingDirections)
        {
            FacingDirection = facingDirections;
            
            if (facingDirections == FacingDirections.Right) 
                Master.transform.localScale = new Vector3(-1, 1, 1);
            else if (facingDirections == FacingDirections.Left)
                Master.transform.localScale = new Vector3(1, 1, 1);
        }

        private void Face()
        {
            if (CanFaceRight())
            {
                Flip(FacingDirections.Right); 
                return;
            }
            if (CanFaceLeft())
            {
                Flip(FacingDirections.Left);
                return;                
            }
        }
        
        private bool CanFaceRight()
            => _movement.CurrentMovement.x > 0 && FacingDirection == FacingDirections.Left;

        private bool CanFaceLeft()
            => _movement.CurrentMovement.x < 0 && FacingDirection == FacingDirections.Right;
    }
}