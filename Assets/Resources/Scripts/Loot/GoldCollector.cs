namespace MolecularSurvivors
{
    public class GoldCollector :  CountChanger
    {
        public int Count { get; private set; }

        public void Collect(int amount)
        {
            Count += amount;
            CountChanged(amount);
        }
    }
}