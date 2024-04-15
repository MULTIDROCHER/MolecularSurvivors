using UnityEngine;

namespace MolecularSurvivors
{
    public class SpeedComponent : ComponentData
    {
        [field: SerializeField] public float Speed { get; private set; }

        public SpeedComponent() => Speed = 5;

        public override ComponentType Type => ComponentType.Speed;

        public override void ChangeValue(float value, bool isPercent = false)
        {
            var amount = value;

            if (isPercent)
                amount = PercentConverter.GetValueByPercent(Speed, value);

            Speed += amount;
            base.ChangeValue(value, isPercent);
        }
    }
}