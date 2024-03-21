using System;
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

        private void Awake()
        {
            _weaponContainer.Initialize(_slotTemplate, _maxAmount);
            _abilityContainer.Initialize(_slotTemplate, _maxAmount);
        }

        private void Start()
        {
            Add(_player.PlayerData.StartWeapon);
            Add(_player.PlayerData.StartAbility);
        }

        public void Add(EquipmentData equipment)
        {
            //todo rewrite
            switch (equipment)
            {
                case WeaponData:
                    if (_weaponContainer.HasEmptySlot())
                    {
                        _weaponContainer.Add(equipment);
                        EquipmentAdded?.Invoke(equipment);
                        Debug.Log("added to weapon");
                    }
                    break;
                case AbilityData:
                    if (_abilityContainer.HasEmptySlot())
                    {
                        _abilityContainer.Add(equipment);
                        EquipmentAdded?.Invoke(equipment);
                        Debug.Log("added to ability");
                    }
                    break;
                default:
                    Debug.Log("cant add equip to inventory");
                    break;
            }
        }

        public bool HasEquipment(EquipmentData equipment)
        {
            return _weaponContainer.HasEquipment(equipment) || _abilityContainer.HasEquipment(equipment);
        }
    }
}