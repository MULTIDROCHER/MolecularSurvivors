using UnityEngine;

namespace MolecularSurvivors
{
    public class TimerComponent : ComponentData
    {
        private readonly float _minDelay = 0.1f;

        private float _timer;

        public TimerComponent() => Cooldown = 5;

        public override ComponentType Type => ComponentType.Delay;

        [field: SerializeField] public float Cooldown { get; private set; }

        public override void ChangeValue(float value, bool isPercent = false)
        {
            var amount = value;

            if (isPercent)
                amount = PercentConverter.GetValueByPercent(Cooldown, value);

            Cooldown = ((Cooldown + amount) > _minDelay) ? Cooldown + amount : _minDelay;

            base.ChangeValue(value, isPercent);
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
    }
}