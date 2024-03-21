using UnityEngine;

namespace MolecularSurvivors
{
    public class DamageComponent : ComponentData, IIncreasable
    {
        [field: SerializeField] public int Damage { get; private set; }

        public DamageComponent() => Damage = 1;

        public void Increase(float value, bool isPercent = false)
        {
            var amount = value;

            if (isPercent)
                amount = PercentConverter.GetValueByPercent(Damage, value);

            Damage += (int)amount;
        }
    }
}