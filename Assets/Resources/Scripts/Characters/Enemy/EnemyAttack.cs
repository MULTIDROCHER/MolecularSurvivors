using System.Collections;
using UnityEngine;
using Zenject;

namespace MolecularSurvivors
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyAttack : MonoBehaviour
    {
        private Enemy _enemy;
        [Inject] private Player _player;
        private WaitForSeconds _wait;
        private bool _inContact = false;

        private void Start()
        {
            _enemy = GetComponent<Enemy>();
            _wait = new(_enemy.Data.AttackDelay);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_player != null && other.gameObject == _player.gameObject)
            {
                _inContact = true;
                StartCoroutine(Attack());
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (_player != null && other.gameObject == _player.gameObject)
                _inContact = false;
        }

        private IEnumerator Attack()
        {
            while (_inContact)
            {
                _player.ApplyDamage(_enemy.Data.Damage);
                yield return _wait;
            }
        }

        private void OnDisable()
        {
            _inContact = false;
            StopAllCoroutines();
        }
    }
}