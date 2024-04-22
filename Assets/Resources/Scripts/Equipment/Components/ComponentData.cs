using System;
using UnityEngine;

namespace MolecularSurvivors
{
    [Serializable]
    public abstract class ComponentData
    {
        public virtual ComponentType Type { get; }

        public event Action ValueChanged;

        public virtual void ChangeValue(float value, bool isPercent = false)
        {
            ValueChanged?.Invoke();
            Debug.Log($"{Type} changed to {value}");
        }
    }
}