using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class EnemySpawner : MonoBehaviour
    {
        private readonly List<Enemy> _spawned = new();

        [SerializeField] private Player _player;
        [SerializeField] private HealthChangesDisplay _healthChangesDisplay;
        [SerializeField] private DropLootManager _dropLoot;
        [SerializeField] private KillsCounter _counter;
        [SerializeField] private int _amount;
        [SerializeField] private List<Enemy> _templates;

        private void Start()
        {
            TestSpawn();
        }

        private void OnDisable()
        {
            foreach (var enemy in _spawned)
                enemy.Health.Died -= OnEnemyDied;
        }

        private void TestSpawn()
        {
            for (int i = 0; i < _amount; i++)
            {
                var enemy = Instantiate(_templates[Random.Range(0, _templates.Count)], transform);
                _spawned.Add(enemy);
                enemy.Set(_player, _healthChangesDisplay);
            }

            foreach(var enemy in _spawned)
                enemy.Health.Died += OnEnemyDied;
        }

        private void OnEnemyDied(Transform transform)
        {
            _dropLoot.InstantiateLoot(transform.position);
            transform.gameObject.SetActive(false);
            _counter?.UpdateCount();
        }
    }
}