using System;
using UnityEngine;

namespace MolecularSurvivors
{
    public class ObjectHealth : Health
    {
        [SerializeField] private int _maxAmount;

        public event Action Died;

        protected override void Set()
        {
            MaxAmount = _maxAmount;
            base.Set();
        }

        protected override void Die() => Died?.Invoke();
    }
}