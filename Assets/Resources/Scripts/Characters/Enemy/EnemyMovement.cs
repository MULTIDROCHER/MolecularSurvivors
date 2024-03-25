using UnityEngine;

namespace MolecularSurvivors
{
    [RequireComponent(typeof(Enemy))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyMovement : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private Vector3 _direction;
        private Enemy _enemy;
        private Transform _target;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _enemy = GetComponent<Enemy>();
            _target = _enemy.Player.transform;
        }

        private void FixedUpdate()
        {
            if (_target != null)
            {
                _direction = (_target.position - transform.position).normalized;
                _rigidbody.velocity = _direction * _enemy.Data.MoveSpeed;
            }
        }
    }
}