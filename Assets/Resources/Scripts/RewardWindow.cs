using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class RewardWindow : MonoBehaviour
    {
        private readonly List<RewardSlot> _slots = new();
        private readonly List<EquipmentData> _loaded = new();

        [SerializeField] private int _amount;
        [SerializeField] private Transform _container;
        [SerializeField] private RewardSlot _slotTemplate;
        [SerializeField] private Inventory _inventory;
        [SerializeField] private EquipmentAssets _assets;
        [SerializeField] private DefaultReward[] _defaultRewards;
        [SerializeField] private Player _player;
        [SerializeField] private EquipmentReward _equipmentReward;

        private void Awake()
        {
            Initialize();
        }

        private void OnEnable()
        {
            Time.timeScale = 0;
            LoadRewards();
        }

        private void OnDisable()
        {
            Time.timeScale = 1;

            foreach (var slot in _slots)
                slot.gameObject.SetActive(false);

            _loaded.Clear();
        }

        public void RewardSelected(IReward data)
        {
            //todo rewrite for event
            switch (data)
            {
                case EquipmentReward equipment:
                    _inventory.Add(equipment.Data);
                    break;
                case DefaultReward defaultReward:
                    RealiseDefaultRevard(defaultReward.Loot);
                    break;
            }

            gameObject.SetActive(false);
        }

        private void RealiseDefaultRevard(Loot loot)
        {
            switch (loot)
            {
                case HpLoot hpLoot:
                    _player.Health.Recover(hpLoot.HealthRecovery);
                    break;
                case GoldLoot goldLoot:
                    _player.GoldCollector.Collect(goldLoot.Gold);
                    break;
                default:
                    return;
            }
        }

        private void LoadRewards()
        {
            if (_inventory.IsFull)
            {
                LoadDefault();
                return;
            }

            for (int i = 0; i < _amount; i++)
            {
                var slot = _slots[i];
                var equipment = GetEquipment();
                _equipmentReward.Set(equipment);

                _loaded.Add(equipment);
                slot.Set(_equipmentReward, _inventory.HasEquipment(equipment) == false);
                slot.gameObject.SetActive(true);
            }
        }

        private void LoadDefault()
        {
            if (_defaultRewards.Length <= _slots.Count)
                for (int i = 0; i < _defaultRewards.Length; i++)
                {
                    var slot = _slots[i];
                    var reward = _defaultRewards[i];

                    slot.Set(reward, true);
                slot.gameObject.SetActive(true);
                }
        }

        private void Initialize()
        {
            for (int i = 0; i < _amount; i++)
            {
                var slot = Instantiate(_slotTemplate, _container);
                _slots.Add(slot);
                slot.gameObject.SetActive(false);
            }
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