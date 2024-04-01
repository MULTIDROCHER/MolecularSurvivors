using System;
using UnityEngine;

namespace MolecularSurvivors
{
    [Serializable]
    public class Level
    {
        [SerializeField] public string Number;
        [SerializeField] private ComponentData _component;
        [SerializeField] private int _value;
        [SerializeField] private bool _isPercent;

        public void LevelUp()
        {
            if (_component is IDecreasable decrasable)
                decrasable.Decrease(_value, _isPercent);
            else if (_component is IIncreasable increasable)
                increasable.Increase(_value, _isPercent);
        }
    }
}