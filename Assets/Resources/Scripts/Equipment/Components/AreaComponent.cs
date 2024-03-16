using UnityEngine;

namespace MolecularSurvivors
{
    public class AreaComponent : ComponentData, IIncreasable
    {
        public AreaComponent() => AreaScale = new(1, 1, 1);

        [field: SerializeField] public Vector3 AreaScale { get; private set; }

        public void Increase(float value, bool isPercent = false)
        {
            Vector3 increasing = new(value, value);

            if (isPercent)
            {
                increasing.x += PercentConverter.GetValueByPercent(AreaScale.x, value);
                increasing.y += PercentConverter.GetValueByPercent(AreaScale.y, value);
            }

            AreaScale += increasing;
        }
    }
}