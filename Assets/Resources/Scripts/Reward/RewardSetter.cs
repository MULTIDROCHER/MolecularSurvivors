using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace MolecularSurvivors
{
    public class RewardSetter : IDisposable
    {
        private readonly Inventory _inventory;
        private readonly EquipmentAssets _assets = new();
        private readonly IReward[] _defaultRewards;
        private readonly List<IReward> _equipmentRewards = new();

        private List<IReward> _rewards = new();

        public RewardSetter(Inventory inventory, DefaultReward[] defaultRewards)
        {
            _inventory = inventory;
            _defaultRewards = defaultRewards;
        }

        public List<IReward> SetRewards()
        {
            _rewards.Clear();
            var equipment = GetMixedEquipment();

            if (equipment.Count <= 0)
            {
                _rewards.AddRange(_defaultRewards);
            }
            else
            {
                if (equipment.Count > _equipmentRewards.Count)
                    CreateEquipmentRewards(equipment.Count - _equipmentRewards.Count);

                for (int i = 0; i < equipment.Count; i++)
                {
                    var rewardData = _equipmentRewards[i] as EquipmentReward;
                    rewardData.Set(equipment[i]);
                    _rewards.Add(rewardData);
                }
            }

            return _rewards;
        }

        private void CreateEquipmentRewards(int amount)
        {
            for (int i = 0; i < amount; i++)
                _equipmentRewards.Add(ScriptableObject.CreateInstance<EquipmentReward>());
        }

        private List<EquipmentData> GetMixedEquipment()
        {
            var equipment = GetNewEquipment();

            if (_inventory.HasEmptyWeaponSlots() == false)
                equipment.RemoveAll(equip => equip is WeaponData);
            if (_inventory.HasEmptyAbilitySlots() == false)
                equipment.RemoveAll(equip => equip is AbilityData);

            equipment.AddRange(GetUpgrades());
            equipment.Distinct();
            return equipment;
        }

        private List<EquipmentData> GetNewEquipment() => _assets.Equipment.Where(equip => _inventory.Equipment.Contains(equip) == false).ToList();

        private List<EquipmentData> GetUpgrades() => _inventory.Equipment.Where(equipment => equipment.LevelData.CanLevelUp).ToList();

        public void Dispose() => _equipmentRewards.Clear();
    }
}