using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyAttack : MonoBehaviour
    {
        private Enemy _enemy;
        private Player _player;
        private WaitForSeconds _wait;
        private bool _inContact = false;

        private void Awake()
        {
            _enemy = GetComponent<Enemy>();
            _player = _enemy.Player;
            _wait = new(_enemy.EnemyData.AttackDelay);
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform == _player.transform)
            {
                _inContact = true;
                StartCoroutine(Attack());
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.transform == _player.transform)
                _inContact = false;
        }

        private IEnumerator Attack()
        {
            while (_inContact)
            {
                _player.Health.Operations.Decrease(_enemy.EnemyData.Damage);
                yield return _wait;
            }
        }
    }
}