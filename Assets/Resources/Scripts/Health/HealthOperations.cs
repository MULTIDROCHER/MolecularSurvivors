using System;
using UnityEngine;

namespace MolecularSurvivors
{
    public class HealthOperations : Health
    {
        public event Action<int> HealthChanged;

        public void Increase(int amount)
        {
            Current = Current += amount <= MaxAmount ?
            Current + amount : MaxAmount;

            HealthChanged?.Invoke(amount);
        }

        public void Decrease(int amount)
        {
            Current = Current - amount >= 0 ?
            Current - amount : 0;
            
            HealthChanged?.Invoke(amount);

            if (Current <= 0)
                Die();
        }

        private void Die()
        {
            if (GetComponentInParent<Player>() == null)
                Destroy(transform.parent.gameObject);
        }
    }
}