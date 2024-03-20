using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "Equipment/Weapon Data")]
    public class WeaponData : EquipmentData
    {
        [field: SerializeReference] public Ammo Ammo { get; private set; }

        [field: SerializeReference] public TimerComponent TimerData { get; private set; } = new();
        [field: SerializeReference] public DamageComponent DamageData { get; private set; } = new();
        [field: SerializeReference] public DurationComponent DurationData { get; private set; } = new();
        [field: SerializeReference] public AmountComponent AmountData { get; private set; } = new();
    }
}