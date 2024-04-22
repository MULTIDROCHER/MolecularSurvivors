using UnityEngine;

namespace MolecularSurvivors
{
    public class PlayerMovement : Movement
    {
        public Vector3 LastMovementVector { get; private set; } = new(1, 0);
        private float _moveX;
        private float _moveY;

        public PlayerMovement(Rigidbody2D rigidbody, float startSpeed) : base(rigidbody, startSpeed)
        {
        }

        private void SetLastMovementVector()
        {
            //if (MovementDirection.x != 0)
                _moveX = MovementDirection.x;

            //if (MovementDirection.y != 0)
                _moveY = MovementDirection.y;

            if (_moveX != 0 || _moveY != 0)
                LastMovementVector = new(_moveX, _moveY);
        }

        public override void SetDirection()
        {
            var moveX = Input.GetAxisRaw("Horizontal");
            var moveY = Input.GetAxisRaw("Vertical");

            MovementDirection = new Vector2(moveX, moveY).normalized;
            SetLastMovementVector();
        }
    }
}