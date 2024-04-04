using UnityEngine;

namespace MolecularSurvivors
{
    public class EnemyMovement : Movement
    {
        private readonly Transform _target;

        public EnemyMovement(Rigidbody2D rigidbody, float startSpeed, Transform player) : base(rigidbody, startSpeed)
        {
            _target = player;
        }

        public override void SetDirection()
        {
            if (_target != null)
                MovementDirection = (_target.position - Rigidbody.transform.position).normalized;
        }
    }
}