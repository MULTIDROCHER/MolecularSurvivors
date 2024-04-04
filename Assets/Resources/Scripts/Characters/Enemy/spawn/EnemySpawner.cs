using System;
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
        private EnemyDistanceController _distanceController;

        public override event Action<int> CountChanged;

        #region mono
            private void Awake()
            {
                _preparer = new(Camera.main);
                _pool = new(_template, transform);
                _distanceController = new(_player.transform, _pool, this);
                _levelProgress.LevelChanged += OnLevelChanged;
            }
    
            private void Start()
            {
                StartCoroutine(_distanceController.ResetEnemies());
                OnLevelChanged();
            }
    
            private void OnDisable()
            {
                _levelProgress.LevelChanged -= OnLevelChanged;
    
                foreach (var enemy in _pool.Spawned)
                    enemy.Died -= OnEnemyDied;
            }
        #endregion

        public void SetEnemy(Enemy enemy)
        {
            if (_preparer.Set(enemy) != null)
                StartCoroutine(_preparer.Set(enemy));
        }

        private void OnEnemyDied(Character<EnemyData> enemy)
        {
            CountChanged?.Invoke(1);
            _lootManager.InstantiateLoot(enemy.transform.position);
            SetEnemy((Enemy)enemy);
        }

        private void SetNewEnemies(Enemy[] enemies)
        {
            foreach (var enemy in enemies)
            {
                enemy.Initialize(_player, _healthChangesDisplay);
                enemy.Died += OnEnemyDied;
                SetEnemy(enemy);
            }
        }

        private void OnLevelChanged()
        {
            var wave = _levelProgress.CurrentLevelRange.EnemyWave;
            var enemies = _pool.CreateNewEnemies(wave.EnemiesCountIncrease);

            _preparer.UpdateDataList(wave);
            SetNewEnemies(enemies);
        }
    }
}