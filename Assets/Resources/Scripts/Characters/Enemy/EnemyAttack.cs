using System.Collections;
using UnityEngine;
using Zenject;

namespace MolecularSurvivors
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyAttack : MonoBehaviour
    {
        private Enemy _enemy;
        private WaitForSeconds _wait;
        private bool _inContact = false;

        private void Start()
        {
            _enemy = GetComponent<Enemy>();
            _wait = new(_enemy.Data.AttackDelay);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (IsPlayer(other))
            {
                _inContact = true;
                StartCoroutine(Attack());
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (IsPlayer(other))
                _inContact = false;
        }

        private IEnumerator Attack()
        {
            while (_inContact)
            {
                _enemy.Player.ApplyDamage(_enemy.Data.Damage);
                yield return _wait;
            }
        }

        private void OnDisable()
        {
            _inContact = false;
            StopAllCoroutines();
        }

        private bool IsPlayer(Collision2D other) => _enemy.Player != null && other.gameObject == _enemy.Player.gameObject;
    }
}