using UnityEngine;

namespace MolecularSurvivors
{
    public class CharacterHealth : Health
    {
        private CharacterData _data;
        private HealthChangesDisplay _changesDisplay;

        public CharacterHealth(Transform damagable, HealthChangesDisplay healthChanges = null) : base(damagable)
        {
            if (healthChanges != null)
                SetDisplay(healthChanges);
        }

        public void Set(CharacterData data)
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
    }
}
