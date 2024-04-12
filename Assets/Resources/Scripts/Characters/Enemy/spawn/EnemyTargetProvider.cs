using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class EnemyTargetProvider
    {
        private Transform _player;
        private Pool _pool;

        public EnemyTargetProvider(Transform player, Pool pool)
        {
            _player = player;
            _pool = pool;
        }

        public Enemy GetRandomEnemy()
        {
            return _pool.Spawned[Random.Range(0, _pool.Spawned.Count)];   
        }
        
        public Enemy GetNearestEnemy()
        {
            if (_pool.Spawned.Count == 0)
                return null;

            Enemy nearestEnemy = null;
            float shortestDistanceSqr = float.MaxValue;

            foreach (var enemy in _pool.Spawned)
            {
                float distanceSqr = (enemy.transform.position - _player.position).sqrMagnitude;
                
                if (distanceSqr < shortestDistanceSqr)
                {
                    shortestDistanceSqr = distanceSqr;
                    nearestEnemy = enemy;
                }
            }

            return nearestEnemy;
        }
    }
}