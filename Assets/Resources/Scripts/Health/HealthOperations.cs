namespace MolecularSurvivors
{
    public class HealthOperations
    {
        private Health _health;

        public HealthOperations(Health health) => _health = health;

        public int CurrentAmount => _health.Current;

        public int Recover(int amount)
        {
            var health = CurrentAmount + amount <= _health.MaxAmount ?
            _health.Current + amount : _health.MaxAmount;

            return health;
        }

        public int ApplyDamage(int amount)
        {
            var health = _health.Current - amount >= 0 ?
            _health.Current - amount : 0;

            if (health <= 0)
                Die();

            return health;
        }

        private void Die()
        {
            if (_health.GetComponentInParent<Player>() == null)
            {
                _health.transform.parent.gameObject.SetActive(false);
            }
        }
    }
}