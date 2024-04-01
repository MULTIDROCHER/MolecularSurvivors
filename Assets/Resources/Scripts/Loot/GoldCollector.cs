using System;

namespace MolecularSurvivors
{
    public class GoldCollector :  CountChanger
    {
        public int Count { get; private set; }
        public override event Action<int> CountChanged;

        public void Collect(int amount)
        {
            Count += amount;
            CountChanged?.Invoke(amount);
        }
    }
}