using System;

namespace MolecularSurvivors
{
    public class EnemyHealth : Health
    {
        private Enemy _enemy;
        private EnemyData _data;
        private HealthChangesDisplay _changesDisplay;

        public event Action<Enemy> Died;

        public void Initialize(Enemy enemy, HealthChangesDisplay healthChanges = null)
        {
            base.Initialize();

            _enemy = enemy;
            if (healthChanges != null)
                SetDisplay(healthChanges);
        }

        public void Set(EnemyData data)
        {
            _data = data;
            MaxAmount = _data.MaxHealth;
            base.Set();
        }

        private void SetDisplay(HealthChangesDisplay changesDisplay)
        {
            _changesDisplay = changesDisplay;
            _changesDisplay.Subscribe(this);
        }

        private void OnDestroy() => _changesDisplay?.Remove(this);

        protected override void Die() => Died?.Invoke(_enemy);
    }
}