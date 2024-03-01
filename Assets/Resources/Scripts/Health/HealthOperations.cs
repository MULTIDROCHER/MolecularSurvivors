using System;
using UnityEngine;

namespace MolecularSurvivors
{
    public class HealthOperations : Health
    {
        [SerializeField] private int _maxAmount;

        public event Action<int> HealthChanged;

        public int MaxAmount => _maxAmount;

        public void Increase(int amount)
        {
            Current = Current += amount <= _maxAmount ?
            Current + amount : _maxAmount;
            HealthChanged?.Invoke(Current);
        }

        public void Decrease(int amount)
        {
            Current = Current - amount >= 0 ?
            Current - amount : 0;
            HealthChanged?.Invoke(Current);

            if (Current <= 0)
                Die();
        }

        private void Die()
        {
            if (GetComponentInParent<Player>() == null)
                Destroy(gameObject);
        }
    }
}