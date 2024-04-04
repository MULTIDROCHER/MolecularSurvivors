using System;
using UnityEngine;

namespace MolecularSurvivors
{
    public abstract class Health
    {
        private readonly HealthOperations _operations;

        public virtual event Action<int, Health> HealthChanged;

        public int MaxAmount { get; protected set; }
        public int Current { get; private set; }
        public Transform Damagable { get; private set; }

        public Health(Transform damagable)
        {
            Damagable = damagable;
            _operations = new(this);
        }

        public void ApplyDamage(int damage)
        {
            if (IsDead() == false)
            {
                Current = _operations.ApplyDamage(damage);
                HealthChanged?.Invoke(-damage, this);
            }
        }

        public void Recover(int amount)
        {
            if (IsDead() == false)
            {
                Current = _operations.Recover(amount);
                HealthChanged?.Invoke(amount, this);
            }
        }

        private bool IsDead() => Current <= 0;

        protected virtual void Set() => Current = MaxAmount;
    }
}