using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class DamageComponent : ComponentData, IIncreasable
    {
        [SerializeField] private int _minDamage;
        [SerializeField] private int _maxDamage;

        public DamageComponent(){
            _minDamage = 1;
            _maxDamage = 10;
        }

        public int GetDamage()
        {
            if (_minDamage >= _maxDamage)
                _minDamage = _maxDamage / 2;

            return Random.Range(_minDamage, _maxDamage);
        }

        public void Increase(float value, bool isPercent = false)
        {
            var amount = value;

            if (isPercent)
                amount = PercentConverter.GetValueByPercent(_maxDamage, value);

            _minDamage += (int)amount;
            _maxDamage += (int)amount;
        }
    }
}