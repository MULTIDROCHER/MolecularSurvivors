using System;
using UnityEngine;

namespace MolecularSurvivors
{
    public abstract class Health : MonoBehaviour
    {
        private HealthOperations _operations;

        public virtual event Action<int> HealthChanged;

        public int MaxAmount { get; protected set; }
        public int Current { get; private set; }

        private void Awake() => Set();

        public virtual void ApplyDamage(int damage)
        {
            if (Current <= 0)
                return;

            Current = _operations.ApplyDamage(damage);
            HealthChanged?.Invoke(Current);

            if (Current <= 0)
                Die();
        }

        public virtual void Recover(int amount)
        {
            Current = _operations.Recover(amount);
            HealthChanged?.Invoke(Current);
        }

        protected virtual void Set()
        {
            Current = MaxAmount;
            _operations = new(this);
        }

        protected abstract void Die();
    }
}