using UnityEngine;

namespace MolecularSurvivors
{
    public class DurationComponent : ComponentData, IIncreasable
    {
        [SerializeField] private float _maxDuration;
        [SerializeField] private float _minDuration;

        public DurationComponent()
        {
            _minDuration = 1;
            _maxDuration = 10;
        }

        public float GetDuration()
        {
            if (_minDuration >= _maxDuration)
                _minDuration = _maxDuration / 2;

            return Random.Range(_minDuration, _maxDuration);
        }

        public void Increase(float value, bool isPercent = false)
        {
            var amount = value;

            if (isPercent)
                amount = PercentConverter.GetValueByPercent(_maxDuration, value);

            _minDuration += amount;
            _maxDuration += amount;
        }
    }
}