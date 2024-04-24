using System;
using UnityEngine;
using Zenject;

namespace MolecularSurvivors
{
    public class EnemySpawner : CountChanger
    {
        [Inject] private readonly Player _player;
        [Inject] private readonly LevelProgress _levelProgress;
        [Inject] private HealthChangesDisplay _changesDisplay;

        [SerializeField] private Enemy _template;
        [SerializeField] private DropLootManager _lootManager;
        [SerializeField] private EnemyEffects _effects;

        private EnemyPool _pool;
        private EnemyPreparer _preparer;
        private EnemyDistanceController _distanceController;
        private EnemyTargetProvider _enemyProvider;

        public override event Action<int> CountChanged;

        #region mono
        private void Awake()
        {
            _preparer = new(Camera.main);
            _pool = new(_template, transform);
            _distanceController = new(_player.transform, _pool, this);
            _enemyProvider = new(_player.transform, _pool);
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

        public Enemy GetNearestEnemy() => _enemyProvider.GetNearestEnemy();

        public Enemy GetRandomEnemy() => _enemyProvider.GetRandomEnemy();

        private void OnEnemyDied(Enemy enemy)
        {
            CountChanged?.Invoke(1);
            _effects.PlayDeathEffect(enemy.transform.position);
            _lootManager.Drop(enemy.transform.position);
            SetEnemy(enemy);
        }

        private void SetNewEnemies(Enemy[] enemies)
        {
            foreach (var enemy in enemies)
            {
                enemy.Initialize(_player, _changesDisplay);
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