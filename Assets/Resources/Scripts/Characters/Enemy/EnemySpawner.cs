using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private HealthChangesDisplay _healthChangesDisplay;
        [SerializeField] private DropLootManager _dropLoot;
        [SerializeField] private int _amount;
        [SerializeField] private List<Enemy> _templates;

        private void Start()
        {
            TestSpawn();
        }

        private void TestSpawn()
        {
            for (int i = 0; i < _amount; i++)
            {
                var enemy = Instantiate(_templates[Random.Range(0, _templates.Count)], transform);
                enemy.Set(_player, _healthChangesDisplay, _dropLoot);
            }
        }
    }
}