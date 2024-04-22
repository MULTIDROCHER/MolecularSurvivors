using UnityEngine;

namespace MolecularSurvivors
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "Equipment/Weapon Data")]
    public class WeaponData : EquipmentData
    {
        [field: SerializeReference] public Ammo Ammo { get; private set; }
        [field: SerializeField] public AmmoPositionType PositionSetterType { get; private set; }
        [field: SerializeField] public DamageComponent DamageData { get; private set; } = new();
        [field: SerializeField] public DurationComponent DurationData { get; private set; } = new();

        #region Editor
        [ContextMenu(nameof(AddAmountComponent))] private void AddAmountComponent() => Components.Add(new AmountComponent());
        [ContextMenu(nameof(AddAreaComponent))] private void AddAreaComponent() => Components.Add(new AreaComponent());
        #endregion
    }
}