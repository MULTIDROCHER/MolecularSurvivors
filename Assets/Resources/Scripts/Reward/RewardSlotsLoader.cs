using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MolecularSurvivors
{
    public class RewardSlotsLoader
    {
        private readonly RewardSetter _setter;
        private readonly Inventory _inventory;
        private readonly List<RewardSlot> _slots;
        private readonly List<IReward> _usedRewards = new();
        
        private IReward _reward;
        private int _amount;

        public RewardSlotsLoader(List<RewardSlot> slots, DefaultReward[] defaultRewards, Inventory inventory)
        {
            _slots = slots;
            _inventory = inventory;
            _setter = new(inventory,defaultRewards);
        }

        public void Reset()
        {
            _usedRewards.Clear();
            _slots.ForEach(slot => slot.gameObject.SetActive(false));
        }

        public void LoadSlots()
        {
            var rewards = _setter.SetRewards();

            if (rewards.Count == 0)
            {
                Debug.Log("No rewards");
                return;
            }
            else
            {
                _amount = _slots.Count < rewards.Count ? _slots.Count : rewards.Count;

                for (int i = 0; i < _amount; i++)
                {
                    do
                        _reward = rewards[Random.Range(0, rewards.Count)];
                    while (_reward == null || _usedRewards.Contains(_reward));

                    _usedRewards.Add(_reward);
                    rewards.Remove(_reward);

                    _slots[i].Set(_reward, IsNew(_reward));
                }
            }
        }

        private bool IsNew(IReward reward) =>
        reward is DefaultReward ||
        reward is EquipmentReward equipment && _inventory.Equipment.Contains(equipment.Data) == false;
    }
}