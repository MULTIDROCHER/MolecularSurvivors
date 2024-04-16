using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MolecularSurvivors
{
    public class RewardLoader
    {
        private readonly Inventory _inventory;
        private readonly RewardSlot[] _slots;
        private readonly DefaultReward[] _defaultRewards;
        private readonly EquipmentReward _equipmentTemplate;
        private readonly EquipmentAssets _assets;
        private List<EquipmentData> _equipmentRewards = new();

        public RewardLoader(Inventory inventory, RewardSlot[] slots, DefaultReward[] defaultRewards, EquipmentReward template)
        {
            _inventory = inventory;
            _slots = slots;
            _defaultRewards = defaultRewards;
            _equipmentTemplate = template;
            _assets = new();
        }

        public void LoadRewards()
        {
            SetReward();
            SetSlots();
        }

        public void Reset()
        {
            foreach (var slot in _slots)
                slot.gameObject.SetActive(false);

            _equipmentRewards.Clear();
        }

        private void SetReward()
        {
            if (_inventory.HasEmptySlots() == false)
                if (_inventory.HasUpgrades() == false)
                    return;
                else
                    _equipmentRewards = GetUpgrades();
            else
                _equipmentRewards = GetMixedEquipment();
        }

        private void SetSlots()
        {
            if (_equipmentRewards.Count == 0)
            {
                for (int i = 0; i < _slots.Length; i++)
                    SetSlot(_slots[i], _defaultRewards[i]);
            }
            else
            {
                List<EquipmentData> used = new();

                for (int i = 0; i < _slots.Length; i++)
                {
                    EquipmentData newEquipment;

                    do
                        newEquipment = _equipmentRewards[UnityEngine.Random.Range(0, _equipmentRewards.Count)];
                    while (newEquipment == null || used.Contains(newEquipment));

                    used.Add(newEquipment);
                    _equipmentRewards.Remove(newEquipment);

                    _equipmentTemplate.Set(newEquipment);
                    SetSlot(_slots[i], _equipmentTemplate);
                }
            }
        }

        private void SetSlot(RewardSlot slot, IReward reward)
        {
            if (reward == null)
            {
                Debug.Log("Reward is null");
                return;
            }
            if (slot == null)
            {
                Debug.Log("slot is null");
                return;
            }

            slot.Set(reward, IsNew(reward));
            slot.gameObject.SetActive(true);
        }

        private bool IsNew(IReward reward)
        {
            if (reward is EquipmentReward equipment)
                if (_inventory.Equipment.Contains(equipment.Data))
                    return false;
                else
                    return true;
            else
            {
                Debug.Log("probably is default");
                return true;
            }
        }

        private List<EquipmentData> GetNewEquipment() => _assets.Equipment.Where(equip => _inventory.Equipment.Contains(equip) == false).ToList();

        private List<EquipmentData> GetUpgrades() => _inventory.Equipment.Where(equipment => equipment.LevelData.CanLevelUp).ToList();

        private List<EquipmentData> GetMixedEquipment() => GetNewEquipment().Concat(GetUpgrades()).ToList();
    }
}