using System.Collections;
using UnityEngine;

namespace MolecularSurvivors
{
    public class EnemyDistanceController
    {
        private readonly EnemySpawner _spawner;
        private readonly EnemyPool _pool;
        private readonly Transform _player;
        private readonly WaitForSeconds _waitBeforeCheck = new(4);
        private readonly float _maxDistance = 20;

        public EnemyDistanceController(Transform player, EnemyPool pool, EnemySpawner spawner)
        {
            _player = player;
            _pool = pool;
            _spawner = spawner;
        }

        public IEnumerator ResetEnemies()
        {
            while (_spawner != null)
            {
                yield return _waitBeforeCheck;

                foreach (var enemy in _pool.Spawned)
                    if (enemy.gameObject.activeSelf
                    && Vector2.Distance(_player.position, enemy.transform.position) > _maxDistance)
                    {
                        enemy.gameObject.SetActive(false);
                        _spawner.SetEnemy(enemy);
                    }
            }
        }
    }
}