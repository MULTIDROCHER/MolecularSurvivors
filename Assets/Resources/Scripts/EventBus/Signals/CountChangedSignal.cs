namespace MolecularSurvivors
{
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