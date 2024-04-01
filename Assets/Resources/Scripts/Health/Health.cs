using System;
using UnityEngine;

namespace MolecularSurvivors
{
    public abstract class Health : MonoBehaviour
    {
        private HealthOperations _operations;

        public virtual event Action<int, Health> HealthChanged;

        public int MaxAmount { get; protected set; }
        public int Current { get; private set; }

        public virtual void Initialize() => _operations ??= new(this);

        public void ApplyDamage(int damage)
        {
            if (Current <= 0)
                return;

            Current = _operations.ApplyDamage(damage);
            HealthChanged?.Invoke(-damage, this);

            if (Current <= 0)
                Die();
        }

        public void Recover(int amount)
        {
            Current = _operations.Recover(amount);
            HealthChanged?.Invoke(amount, this);
        }

        protected virtual void Set() => Current = MaxAmount;

        protected abstract void Die();
    }
}