using System;
using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class RewardLoader
    {
        private readonly int _slotsAmount;
        private readonly Inventory _inventory;
        private readonly RewardSlot[] _slots;
        private readonly DefaultReward[] _defaultRewards;
        private readonly EquipmentReward _equipmentReward;
        private readonly List<EquipmentData> _loaded = new();
        private readonly EquipmentAssets _assets;

        public RewardLoader
        (Inventory inventory, int amount, RewardSlot[] slots, DefaultReward[] defaultRewards, EquipmentReward equipmentReward)
        {
            _inventory = inventory;
            _slotsAmount = amount;
            _slots = slots;
            _defaultRewards = defaultRewards;
            _equipmentReward = equipmentReward;
            _assets = new();
        }

        public void LoadRewards()
        {
            if (_inventory.HasUpgradeables && _inventory.IsFull == false)
                LoadMixed();
            else if (_inventory.HasUpgradeables)
                LoadUpgrades();
            else
                LoadDefault();
        }

        private void LoadUpgrades()
        {
            for (int i = 0; i < _slotsAmount; i++)
            {
                var slot = _slots[i];
                var equipment = GetUpgrade();

                _equipmentReward.Set(equipment);
                _loaded.Add(equipment);
                slot.Set(_equipmentReward, _inventory.HasEquipment(equipment) == false);
                slot.gameObject.SetActive(true);
            }
        }

        private void LoadMixed()
        {
            int index;

            for (int i = 0; i < _slotsAmount; i++)
            {
                var slot = _slots[i];
                index = UnityEngine.Random.Range(0, 2);

                var equipment = index == 0 ? GetUpgrade() : GetEquipment();

                _equipmentReward.Set(equipment);
                _loaded.Add(equipment);

                if (_inventory.HasEquipment(equipment))
                    slot.SetAsUpgrade(equipment);
                else
                    slot.Set(_equipmentReward, _inventory.HasEquipment(equipment) == false);

                slot.gameObject.SetActive(true);
            }
        }

        public void LoadDefault()
        {
            if (_defaultRewards.Length <= _slots.Length)
                for (int i = 0; i < _defaultRewards.Length; i++)
                {
                    var slot = _slots[i];
                    var reward = _defaultRewards[i];

                    slot.Set(reward, true);
                    slot.gameObject.SetActive(true);
                }
        }

        public void Reset()
        {
            foreach (var slot in _slots)
                slot.gameObject.SetActive(false);

            _loaded.Clear();
        }

        private EquipmentData GetEquipment()
        {
            var equipment = _assets.GetRandomEquipment();

            while (_loaded.Contains(equipment))
                equipment = _assets.GetRandomEquipment();

            return equipment;
        }

        private EquipmentData GetUpgrade()
        {
            var equipment = _inventory.GetRandomEquipmentsUpgrade();

            if (equipment == null)
                return GetEquipment();
            else
                while (_loaded.Contains(equipment))
                    equipment = _inventory.GetRandomEquipmentsUpgrade();

            return equipment;
        }
    }
}