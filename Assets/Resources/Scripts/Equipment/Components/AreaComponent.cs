using System;
using UnityEngine;

namespace MolecularSurvivors
{
    public class AreaComponent : ComponentData
    {
        private Vector3 _newArea;

        public override ComponentType Type => ComponentType.Area;

        [field: SerializeField] public Vector3 AreaScale { get; private set; } = new(1, 1, 1);

        public override void ChangeValue(float value, bool isPercent = false)
        {
            _newArea = new(value, value);

            if (isPercent)
            {
                _newArea.x += PercentConverter.GetValueByPercent(AreaScale.x, value);
                _newArea.y += PercentConverter.GetValueByPercent(AreaScale.y, value);
            }

            AreaScale += _newArea;
            base.ChangeValue(value, isPercent);
        }
    }
}