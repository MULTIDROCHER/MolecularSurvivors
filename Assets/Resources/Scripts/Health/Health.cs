using System;
using UnityEngine;

namespace MolecularSurvivors
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private CharacterData _character;

        private HealthChangesDisplay _changesDisplay;

        public event Action<string, Vector3> DamageTaken;
        public event Action<int> HealthChanged;

        public HealthOperations Operations { get; private set; }

        public int Current { get; private set; }

        public int MaxAmount { get; private set; }

        private void Awake()
        {
            MaxAmount = _character.MaxHealth;
            Current = _character.MaxHealth;
            Operations = new(this);
        }

        public void SetDisplay(HealthChangesDisplay changesDisplay)
        {
            _changesDisplay = changesDisplay;
            _changesDisplay.Subscribe(this);
        }

        private void OnDestroy()
        {
            _changesDisplay?.Remove(this);
        }

        public void ApplyDamage(int damage)
        {
            Current = Operations.ApplyDamage(damage);

            DamageTaken?.Invoke("-" + damage, transform.position);
            HealthChanged?.Invoke(Current);
        }

        public void Recover(int amount)
        {
            Current = Operations.Recover(amount);

            DamageTaken?.Invoke("++++++++++" + amount, transform.position);
            HealthChanged?.Invoke(Current);
        }
    }
}