using UnityEngine;

namespace MolecularSurvivors
{
    public class ThrowingComponent : ComponentData, IIncreasable
    {
        [field: SerializeField] public float Speed { get; private set; }

        public ThrowingComponent() => Speed =  5;

        public void Increase(float value, bool isPercent = false)
        {
            var amount = value;

            if (isPercent)
                amount = PercentConverter.GetValueByPercent(Speed, value);

            Speed += amount;
        }
    }
}