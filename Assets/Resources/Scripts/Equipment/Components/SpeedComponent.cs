using UnityEngine;

namespace MolecularSurvivors
{
    public class SpeedComponent : ComponentData, IIncreasable
    {
        [field: SerializeField] public float Speed { get; private set; }

        public SpeedComponent() => Speed =  5;

        public void Increase(float value, bool isPercent = false)
        {
            var amount = value;

            if (isPercent)
                amount = PercentConverter.GetValueByPercent(Speed, value);

            Speed += amount;
        }
    }
}