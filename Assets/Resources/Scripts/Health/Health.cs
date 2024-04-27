using UnityEngine;

namespace MolecularSurvivors
{
    public abstract class Health
    {
        private readonly HealthOperations _operations;

        //public virtual event Action<Health> HealthChanged;

        public int MaxAmount { get; protected set; }
        public int Current { get; private set; }
        public int LastChange { get; private set; }
        public Transform Damagable { get; private set; }

        public Health(Transform damagable)
        {
            Damagable = damagable;
            _operations = new(this);
        }

        public virtual void ApplyDamage(int damage)
        {
            if (IsDead() == false)
            {
                Current = _operations.ApplyDamage(damage);
                LastChange = -damage;
                //HealthChanged?.Invoke(this);
            }
        }

        public virtual void Recover(int amount)
        {
            if (IsDead() == false)
            {
                Current = _operations.Recover(amount);
                LastChange = amount;
                //HealthChanged?.Invoke(this);
            }
        }

        private bool IsDead() => Current <= 0;

        protected virtual void Set() => Current = MaxAmount;
    }
}