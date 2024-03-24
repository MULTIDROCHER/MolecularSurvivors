using UnityEngine;

namespace MolecularSurvivors
{
    public class TimerComponent : ComponentData, IDecreasable
    {
        private float _timer;

        public TimerComponent() => Cooldown = 5;

        [field: SerializeField] public float Cooldown { get; private set; }

        public void Decrease(float value, bool isPercent = false)
        {
            var amount = value;

            if (isPercent)
                amount = PercentConverter.GetValueByPercent(Cooldown, value);

            if (CanDecrease(Cooldown - amount))
                Cooldown -= amount;
        }

        public bool ReadyToAttack()
        {
            if (_timer >= Cooldown)
            {
                _timer = 0;
                return true;
            }
            else
            {
                _timer += Time.deltaTime;
                return false;
            }
        }

        public bool CanDecrease(float value) => value >= 0;
    }
}