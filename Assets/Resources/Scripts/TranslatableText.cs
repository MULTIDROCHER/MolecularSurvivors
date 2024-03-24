using System;
using UnityEngine;

namespace MolecularSurvivors
{
    [Serializable]
    public class TranslatableText
    {
        [field: SerializeField] public string Ru { get; private set; }
        [field: SerializeField] public string En { get; private set; }
        [field: SerializeField] public string Tr { get; private set; }
    }
}