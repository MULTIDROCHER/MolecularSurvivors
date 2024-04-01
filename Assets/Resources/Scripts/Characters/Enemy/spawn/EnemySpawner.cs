using System;
using System.Collections;
using UnityEngine;

namespace MolecularSurvivors
{
    public class EnemySpawner : CountChanger
    {
        [SerializeField] private Player _player;
        [SerializeField] private Enemy _template;
        [SerializeField] private HealthChangesDisplay _healthChangesDisplay;
        [SerializeField] private LevelProgress _levelProgress;
        [SerializeField] private DropLootManager _lootManager;

        private Pool _pool;
        private EnemyPreparer _preparer;

        public override event Action<int> CountChanged;

        private void Start()
        {
            _preparer = new(Camera.main);
            _pool = new(_template, transform);
            OnLevelChanged();
        }

        private void OnEnable() => _levelProgress.LevelChanged += OnLevelChanged;

        private void OnDisable()
        {
            _levelProgress.LevelChanged -= OnLevelChanged;

            foreach (var enemy in _pool.Spawned)
                enemy.Health.Died -= OnEnemyDied;
        }

        private void OnEnemyDied(Enemy enemy)
        {
            if (ResetEnemy(enemy) != null)
                StartCoroutine(ResetEnemy(enemy));
        }

        private IEnumerator ResetEnemy(Enemy enemy)
        {
            CountChanged?.Invoke(1);
            _lootManager.InstantiateLoot(enemy.transform.position);
            enemy.gameObject.SetActive(false);
            yield return new WaitForSeconds(.5f);
            _preparer.Set(enemy);
        }

        private void OnLevelChanged()
        {
            var wave = _levelProgress.CurrentLevelRange.EnemyWave;
            var enemies = _pool.CreateNewEnemies(wave.EnemiesCountIncrease);

            _preparer.UpdateDataList(wave);
            StartCoroutine(SetNewEnemies(enemies));
        }

        private IEnumerator SetNewEnemies(Enemy[] enemies)
        {
            foreach (var enemy in enemies)
            {
                enemy.Initialize(_player, _healthChangesDisplay);
                _preparer.Set(enemy);
                enemy.Health.Died += OnEnemyDied;
                yield return new WaitForSeconds(.5f);
            }
        }
    }
}