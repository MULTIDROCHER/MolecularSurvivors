using UnityEngine;

namespace MolecularSurvivors
{
    [RequireComponent(typeof(Player))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        private PlayerData _player;
        private Rigidbody2D _rigidbody;

        private float _speed => _player.MoveSpeed;

        public Vector2 Movement { get; private set; }

        public Vector3 LastMovementVector { get; private set; } = new(1, 0);

        private void Awake()
        {
            _player = GetComponent<Player>().Data;
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update() => GetInput();

        private void LateUpdate() => Move();

        private void GetInput()
        {
            var moveX = Input.GetAxisRaw("Horizontal");
            var moveY = Input.GetAxisRaw("Vertical");

            Movement = new Vector2(moveX, moveY).normalized;
            SetLastMovementVector();
        }

        private void SetLastMovementVector()
        {
            float moveX = 0;
            float moveY = 0;

            if (Movement.x != 0)
                moveX = Movement.x;
            if (Movement.y != 0)
                moveY = Movement.y;

            if (moveX != 0 || moveY != 0)
                LastMovementVector = new(moveX, moveY);
        }

        private void Move()
        {
            Movement *= _speed;
            _rigidbody.velocity = Movement;
        }
    }
}