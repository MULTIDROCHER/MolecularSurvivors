using UnityEngine;

namespace MolecularSurvivors
{
    public class PlayerHealth : Health
    {
        private PlayerData _data;
        private HealthChangesDisplay _changesDisplay;

        public void Initialize(HealthChangesDisplay healthChanges = null)
        {
            base.Initialize();

            if (healthChanges != null)
                SetDisplay(healthChanges);
        }

        public void Set(PlayerData data)
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

        protected override void Die()
        {
            Debug.Log("player died");
        }
    }
}
