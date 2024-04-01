using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class Pool
    {
        private readonly Enemy _template;
        private readonly Transform _container;

        public List<Enemy> Spawned { get; private set; } = new();

        public Pool(Enemy template, Transform container)
        {
            _template = template;
            _container = container;
        }

        public Enemy[] CreateNewEnemies(int amount)
        {
            var enemies = new Enemy[amount];

            for (int i = 0; i < amount; i++)
            {
                var enemy = InstantiateEnemy();
                Spawned.Add(enemy);
                enemies[i] = enemy;
            }

            return enemies;
        }

        private Enemy InstantiateEnemy()
        {
            var enemy = Object.Instantiate(_template, _container);
            enemy.gameObject.SetActive(false);

            return enemy;
        }
    }
}