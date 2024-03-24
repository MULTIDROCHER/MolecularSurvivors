using System;
using UnityEngine;

namespace MolecularSurvivors
{
    public class CharactersHealth : Health
    {
        [SerializeField] private CharacterData _character;

        private HealthChangesDisplay _changesDisplay;
        public event Action<string, Vector3> DamageTaken;
        public event Action<Transform> Died;

        private void OnDestroy()
        {
            _changesDisplay?.Remove(this);
        }

        public override void ApplyDamage(int amount)
        {
            base.ApplyDamage(amount);
            DamageTaken?.Invoke("-" + amount, transform.position);
        }

        public override void Recover(int amount){
            base.Recover(amount);
            DamageTaken?.Invoke("+++++" + amount, transform.position);
        }

        protected override void Set()
        {
            MaxAmount = _character.MaxHealth;
            base.Set();
        }

        public void SetDisplay(HealthChangesDisplay changesDisplay)
        {
            _changesDisplay = changesDisplay;
            _changesDisplay.Subscribe(this);
        }

        protected override void Die()
        {
            Died?.Invoke(transform.parent);
        }
    }
}