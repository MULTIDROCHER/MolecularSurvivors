using System;
using UnityEngine;

namespace MolecularSurvivors
{
    public class BreakableObject : MonoBehaviour, IDamagable
    {
        [SerializeField] private int _maxHealth = 3;
        public ObjectHealth Health { get; private set; }

        public event Action<BreakableObject> Breaked;

        private void Awake()
        {
            Health = new ObjectHealth(transform, _maxHealth);
        }

        public void ApplyDamage(int amount)
        {
            Health.ApplyDamage(amount);

            if (Health.Current <= 0)
                Breaked?.Invoke(this);
        }

        public void Rebuild()
        {
            gameObject.SetActive(true);
            Health.Recover(_maxHealth);
        }
    }
}