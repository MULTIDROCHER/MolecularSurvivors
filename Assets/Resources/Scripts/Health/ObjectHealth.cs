using UnityEngine;

namespace MolecularSurvivors
{
    public class ObjectHealth : Health
    {
        public ObjectHealth(Transform damagable, int maxAmount)
        : base(damagable)
        {
            MaxAmount = maxAmount;
            base.Set();
        }
    }
}