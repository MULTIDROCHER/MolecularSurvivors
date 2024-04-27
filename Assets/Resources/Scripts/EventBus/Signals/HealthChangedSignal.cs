namespace MolecularSurvivors
{
    public class HealthChangedSignal
    {
        public readonly Health Health;
        public readonly int Value;

        public HealthChangedSignal(Health health, int value)
        {
            Health = health;
            Value = value;
        }
    }

    public class CountChangedSignal
    {
        public readonly CountableType Type;
        public readonly int Value;

        public CountChangedSignal(CountableType type, int value)
        {
            Type = type;
            Value = value;
        }
    }
}