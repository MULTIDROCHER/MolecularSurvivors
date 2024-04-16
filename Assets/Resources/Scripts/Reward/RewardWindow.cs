using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class RewardWindow : MonoBehaviour
    {
        private readonly List<RewardSlot> _slots = new();

        [SerializeField] private int _slotsAmount;
        [SerializeField] private Transform _container;
        [SerializeField] private RewardSlot _slotTemplate;
        [SerializeField] private DefaultReward[] _defaultRewards;
        [SerializeField] private Player _player;
        [SerializeField] private TimeControl _timeController;
        [SerializeField] private EquipmentReward _equipmentTemplate;

        private RewardLoader _loader;
        private ResourceHandler _resourceHandler;
        private Inventory _inventory;


        private void Awake()
        {
            Initialize();
            _resourceHandler = _player.ResourceHandler;
            _inventory = _player.Inventory;
            _loader = new(_inventory, _slots.ToArray(), _defaultRewards, _equipmentTemplate);
        }

        private void Initialize()
        {
            for (int i = 0; i < _slotsAmount; i++)
            {
                var slot = Instantiate(_slotTemplate, _container);
                slot.gameObject.SetActive(false);
                _slots.Add(slot);
            }
        }

        private void OnEnable()
        {
            _loader.LoadRewards();
            _timeController.StopTime();
        }

        private void OnDisable()
        {
            _loader.Reset();
            _timeController.StartTime();
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
                    _resourceHandler.GetLoot(defaultReward.Loot);
                    break;
            }

            gameObject.SetActive(false);
        }
    }
}