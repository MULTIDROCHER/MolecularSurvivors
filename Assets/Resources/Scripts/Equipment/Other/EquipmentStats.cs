using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class EquipmentStats : MonoBehaviour
    {
        [field: SerializeField] public int Damage { get; private set; } = 1;
        [field: SerializeField] public float AmmoScale { get; private set; } = 1;
        [field: SerializeField] public float Lifetime { get; private set; }
        [field: SerializeField] public float CooldownDecrease { get; private set; }
    }
}