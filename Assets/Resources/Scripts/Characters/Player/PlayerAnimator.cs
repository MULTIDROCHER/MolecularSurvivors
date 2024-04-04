using UnityEngine;

namespace MolecularSurvivors
{
    public class PlayerAnimator
    {
        private readonly Movement _movement;
        private readonly Animator _animator;
        private readonly int _horizontalHash;
        private readonly int _verticalHash;

        public PlayerAnimator(Movement movement, Animator animator)
        {
            _movement = movement;
            _animator = animator;

            _horizontalHash = Animator.StringToHash("Horizontal");
            _verticalHash = Animator.StringToHash("Vertical");
        }

        public void Update()
        {
            _animator.SetFloat(_horizontalHash, _movement.MovementDirection.x);
            _animator.SetFloat(_verticalHash, _movement.MovementDirection.y);
        }
    }
}