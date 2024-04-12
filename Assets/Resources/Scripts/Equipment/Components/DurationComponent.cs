using System.Collections;
using UnityEngine;

namespace MolecularSurvivors
{
    public class DurationComponent : ComponentData, IIncreasable
    {
        [field: SerializeField] public float Duration { get; private set; }

        private WaitForSeconds _wait;

        public DurationComponent()
        {
            Duration = 1;
            _wait = new(Duration);
        }

        public void Increase(float value, bool isPercent = false)
        {
            var amount = value;

            if (isPercent)
                amount = PercentConverter.GetValueByPercent(Duration, value);

            Duration += amount;
            _wait = new(Duration);
        }

        public IEnumerator Deactivate(Ammo ammo)
        {
            yield return _wait;
            ammo.Deactivate();
        }
    }
}