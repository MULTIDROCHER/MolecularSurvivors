using System.Collections;
using UnityEngine;

namespace MolecularSurvivors
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Player _target;
        [SerializeField] private float _speed;
        [SerializeField] private int _damage;
        [SerializeField] private float _delay;

        Rigidbody2D _rigidbody;
        private Vector3 _direction;
        private WaitForSeconds _wait;
        private bool _inContact = false;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _wait = new(_delay);
        }

        private void FixedUpdate()
        {
            _direction = (_target.transform.position - transform.position).normalized;
            _rigidbody.velocity = _direction * _speed;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform == _target.transform)
            {
                _inContact = true;
                StartCoroutine(Attack());
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.transform == _target.transform)
                _inContact = false;
        }

        private IEnumerator Attack()
        {
            while (_inContact)
            {
                _target.Health.Operations.Decrease(_damage);
                yield return _wait;
            }
        }
    }
}