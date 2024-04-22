using System;
using UnityEngine;

namespace MolecularSurvivors
{
    [Serializable]
    public class UpgradeData
    {
        [field: SerializeField] public TranslatableText Description { get; private set; } = new();

        [field: SerializeField] public ComponentType Type { get; private set; }

        [field: SerializeField] public bool ForAll { get; private set; }

        [field: SerializeField] public float Value { get; private set; }

        [field: SerializeField] public bool IsPercent { get; private set; }
    }
}
