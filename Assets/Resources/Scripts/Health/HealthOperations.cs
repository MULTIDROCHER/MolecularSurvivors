namespace MolecularSurvivors
{
    public class HealthOperations
    {
        private readonly Health _health;

        public HealthOperations(Health health) => _health = health;

        public int CurrentAmount => _health.Current;

        public int ApplyDamage(int amount)
        {
            return _health.Current - amount >= 0 ? _health.Current - amount : 0;
        }

        public int Recover(int amount)
        {
            return CurrentAmount + amount <= _health.MaxAmount ? _health.Current + amount : _health.MaxAmount;
        }
    }
}