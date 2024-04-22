using UnityEngine;

namespace MolecularSurvivors
{
    public class DamageComponent : ComponentData
    {
        [field: SerializeField] public int Damage { get; private set; }

        public override ComponentType Type => ComponentType.Damage;

        public DamageComponent() => Damage = 1;

        public override void ChangeValue(float value, bool isPercent = false)
        {
            var amount = value;

            if (isPercent)
                amount = PercentConverter.GetValueByPercent(Damage, value);

            Damage += (int)amount;
            base.ChangeValue(value, isPercent);
        }
    }
}