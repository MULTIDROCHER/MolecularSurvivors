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

    public class ShowHealthChangesSignal
    {
        public readonly HealthChangedSignal Signal;

        public ShowHealthChangesSignal(HealthChangedSignal signal)
        {
            Signal = signal;
        }
    }
}