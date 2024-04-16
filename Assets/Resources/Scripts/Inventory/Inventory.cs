using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class Inventory : MonoBehaviour
    {
        [Min(1)][SerializeField] private int _maxAmount = 4;
        [SerializeField] private InventoryBlock _weaponContainer;
        [SerializeField] private InventoryBlock _abilityContainer;
        [SerializeField] private Player _player;

        public event Action<EquipmentData> EquipmentAdded;

        public List<EquipmentData> Equipment { get; private set; } = new();

        private void Awake()
        {
            _weaponContainer.Initialize(_maxAmount);
            _abilityContainer.Initialize(_maxAmount);
        }

        private void Start()
        {
            Add(_player.Data.StartWeapon);
            Add(_player.Data.StartAbility);
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

        public bool HasEmptySlots()
        {
            var slots = _weaponContainer.GetEmptySlots().Concat(_abilityContainer.GetEmptySlots()).ToList();
            return slots.Count() > 0;
        }

        public bool HasUpgrades()
        {
            var upgrades = Equipment.Where(equipment => equipment.LevelData.CanLevelUp);
            return upgrades.Count() > 0;
        }
    }
}