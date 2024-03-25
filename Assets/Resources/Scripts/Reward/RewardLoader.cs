using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class RewardLoader
    {
        private readonly int _slotsAmount;
        private readonly Inventory _inventory;
        private readonly EquipmentAssets _assets;
        private readonly RewardSlot[] _slots;
        private readonly DefaultReward[] _defaultRewards;
        private readonly EquipmentReward _equipmentReward;
        private readonly List<EquipmentData> _loaded = new();

        public RewardLoader(Inventory inventory, int amount, EquipmentAssets assets, RewardSlot[] slots, DefaultReward[] defaultRewards, EquipmentReward equipmentReward)
        {
            _inventory = inventory;
            _slotsAmount = amount;
            _assets = assets;
            _slots = slots;
            _defaultRewards = defaultRewards;
            _equipmentReward = equipmentReward;
            Debug.Log("loader loaded");
        }

        public void LoadEquipment()
        {
            for (int i = 0; i < _slotsAmount; i++)
            {
                var slot = _slots[i];
                var equipment = GetEquipment();
                _equipmentReward.Set(equipment);

                _loaded.Add(equipment);
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

            while (_loaded.Contains(equipment) || equipment.LevelData.CanLevelUp == false)
                equipment = _assets.GetRandomEquipment();

            return equipment;
        }
    }
}