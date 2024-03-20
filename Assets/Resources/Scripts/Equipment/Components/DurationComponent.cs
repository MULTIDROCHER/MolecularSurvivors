using UnityEngine;

namespace MolecularSurvivors
{
    public class DurationComponent : ComponentData, IIncreasable
    {
        [field: SerializeField] public float Duration { get; private set; }

        public DurationComponent() => Duration = 1;

        public void Increase(float value, bool isPercent = false)
        {
            var amount = value;

            if (isPercent)
                amount = PercentConverter.GetValueByPercent(Duration, value);

            Duration += amount;
        }
    }
}