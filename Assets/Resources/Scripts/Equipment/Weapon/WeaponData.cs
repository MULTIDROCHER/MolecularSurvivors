using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "Equipment/Weapon Data")]
    public class WeaponData : EquipmentData
    {
        [field: SerializeReference] public Ammo Ammo { get; private set; }
        [field: SerializeReference] public AmountComponent AmountData { get; private set; } = new();
        [field: SerializeReference] public DamageComponent DamageData { get; private set; } = new();
        [field: SerializeField] public AmmoPositionSetter PositionSetter { get; private set; }
        [field: SerializeReference] public SpeedComponent SpeedData { get; private set; } = new();
    }
}