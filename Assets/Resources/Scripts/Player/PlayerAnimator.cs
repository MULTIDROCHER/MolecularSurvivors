using UnityEngine;

namespace MolecularSurvivors
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerAnimator : MonoBehaviour
    {
        private PlayerMovement _movement;
        private Animator _animator;
        private int _horizontalHash;
        private int _verticalHash;

        private void Awake()
        {
            _movement = GetComponent<PlayerMovement>();
            _animator = GetComponentInChildren<Animator>();

            _horizontalHash = Animator.StringToHash("Horizontal");
            _verticalHash = Animator.StringToHash("Vertical");
        }

        private void Update()
        {
            _animator.SetFloat(_horizontalHash, _movement.Movement.x);
            _animator.SetFloat(_verticalHash, _movement.Movement.y);
        }
    }
}