using System.Collections;
using UnityEngine;

namespace MolecularSurvivors
{
    public class DurationComponent : ComponentData
    {
        [field: SerializeField] public float Duration { get; private set; }

        private WaitForSeconds _wait;

        public override ComponentType Type => ComponentType.Duration;

        public DurationComponent()
        {
            Duration = 1;
            _wait = new(Duration);
        }

        public override void ChangeValue(float value, bool isPercent = false)
        {
            var amount = value;

            if (isPercent)
                amount = PercentConverter.GetValueByPercent(Duration, value);

            Duration += amount;
            _wait = new(Duration);
            base.ChangeValue(value, isPercent);
        }

        public IEnumerator Deactivate(Ammo ammo)
        {
            yield return _wait;
            ammo.Deactivate();
        }
    }
}