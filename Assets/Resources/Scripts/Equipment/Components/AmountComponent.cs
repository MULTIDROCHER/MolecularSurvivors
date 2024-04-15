using System;
using UnityEngine;

namespace MolecularSurvivors
{
    public class AmountComponent : ComponentData
    {
        public AmountComponent()
        {
            MaxAmount = 15;
            Amount = 1;
        }

        [field: SerializeField] public int MaxAmount { get; private set; }

        [field: SerializeField] public int Amount { get; private set; }

        public override ComponentType Type => ComponentType.Amount;

        public override void ChangeValue(float value, bool isPercent = false)
        {
            var amount = value;

            if (isPercent)
                amount = PercentConverter.GetValueByPercent(MaxAmount, value);

            Amount += (int)amount;
            base.ChangeValue(value, isPercent);
        }
    }
}