namespace MolecularSurvivors
{
    public interface IDecreasable
    {
        public bool CanDecrease(float value);

        public void Decrease(float value, bool isPercent = false);
    }
}