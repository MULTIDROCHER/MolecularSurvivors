using UnityEngine;
using Zenject;

namespace MolecularSurvivors
{
    public class CharacterHealth : Health
    {
        private CharacterData _data;
        private HealthChangesDisplay _changesDisplay;

        public CharacterHealth(Transform damagable, HealthChangesDisplay changesDisplay) : base(damagable)
        {
            Construct(changesDisplay);
        }

        public void Set(CharacterData data)
        {
            _data = data;
            MaxAmount = _data.MaxHealth;
            base.Set();
        }

        public void Construct(HealthChangesDisplay changesDisplay)
        {
            _changesDisplay = changesDisplay;
            _changesDisplay.Subscribe(this);
        }

        private void OnDestroy() => _changesDisplay?.Remove(this);
    }
}
