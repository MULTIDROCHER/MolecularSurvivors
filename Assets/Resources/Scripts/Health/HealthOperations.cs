using System;

namespace MolecularSurvivors
{
    public class HealthOperations
    {
        private readonly Health _health;

        public HealthOperations(Health health) => _health = health;

        public int ApplyDamage(int amount) => Math.Clamp(_health.Current - amount, 0, _health.MaxAmount);

        public int Recover(int amount) => Math.Clamp(_health.Current + amount, 0, _health.MaxAmount);
    }
}