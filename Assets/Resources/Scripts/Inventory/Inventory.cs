using System;
using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private int _maxAmount = 4;
        [SerializeField] private InventorySlot _slotTemplate;
        [SerializeField] private InventoryBlock _weaponContainer;
        [SerializeField] private InventoryBlock _abilityContainer;
        [SerializeField] private Player _player;

        public event Action<EquipmentData> EquipmentAdded;

        public bool IsFull => _weaponContainer.HasEmptySlot() == false && _abilityContainer.HasEmptySlot() == false;

        public bool HasUpgradeables => _abilityContainer.Upgradables.Count > 0 || _weaponContainer.Upgradables.Count > 0;

        private void Awake()
        {
            _weaponContainer.Initialize(_slotTemplate, _maxAmount);
            _abilityContainer.Initialize(_slotTemplate, _maxAmount);
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
            }
        }

        private void Add(InventoryBlock block, EquipmentData equipment)
        {
            if (block.HasEmptySlot())
            {
                EquipmentAdded?.Invoke(equipment);
                block.Add(equipment);
            }
        }

        public bool HasEquipment(EquipmentData equipment)
        {
            return _weaponContainer.HasEquipment(equipment) || _abilityContainer.HasEquipment(equipment);
        }

        public EquipmentData GetRandomEquipmentsUpgrade()
        {
            List<EquipmentData> upgrades = new();
            upgrades.AddRange(_weaponContainer.Upgradables);
            upgrades.AddRange(_abilityContainer.Upgradables);

            return upgrades[UnityEngine.Random.Range(0, upgrades.Count)];
        }
    }
}