using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class Inventory : MonoBehaviour
    {
        [Min(1)][SerializeField] private int _slotsAmount = 4;
        [SerializeField] private InventoryBlock _weaponContainer;
        [SerializeField] private InventoryBlock _abilityContainer;

        public event Action<EquipmentData> EquipmentAdded;

        public List<EquipmentData> Equipment { get; private set; } = new();

        private void Awake()
        {
            _weaponContainer.Initialize(_slotsAmount);
            _abilityContainer.Initialize(_slotsAmount);
        }

        public void Add(EquipmentData equipment)
        {
            switch (equipment)
            {
                case WeaponData:
                    Add(_weaponContainer, equipment);
                    break;
                case AbilityData:
                    Add(_abilityContainer, equipment);
                    break;
                default:
                    throw new Exception("Unhandled case");
            }
        }

        private void Add(InventoryBlock block, EquipmentData equipment)
        {
            EquipmentAdded?.Invoke(equipment);
            block.Add(equipment);

            if (Equipment.Contains(equipment) == false)
                Equipment.Add(equipment);
        }

        public bool HasEmptyWeaponSlots() => _weaponContainer.GetEmptySlots().Any();

        public bool HasEmptyAbilitySlots() => _abilityContainer.GetEmptySlots().Any();
    }
}