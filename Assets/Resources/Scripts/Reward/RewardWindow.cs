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
        [SerializeField] private Inventory _inventory;
        [SerializeField] private EquipmentAssets _assets;
        [SerializeField] private DefaultReward[] _defaultRewards;
        [SerializeField] private Player _player;
        [SerializeField] private EquipmentReward _equipmentReward;

        private RewardLoader _loader;

        private void Awake()
        {
            Initialize();
            _loader = new(_inventory, _slotsAmount, _assets, _slots.ToArray(), _defaultRewards, _equipmentReward);
        }

        private void OnEnable()
        {
            Time.timeScale = 0;
            LoadRewards();
        }

        private void OnDisable()
        {
            Time.timeScale = 1;
            _loader.Reset();
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
                    _player.ResourceHandler.GetLoot(defaultReward.Loot);
                    break;
            }

            gameObject.SetActive(false);
        }

        private void LoadRewards()
        {
            //add logic for full inventrory but not all equipments has maxlevel
            switch (_inventory.IsFull)
            {
                case false:
                    _loader.LoadEquipment();
                    break;
                default:
                    _loader.LoadDefault();
                    break;
            }
        }

        private void Initialize()
        {
            for (int i = 0; i < _slotsAmount; i++)
            {
                var slot = Instantiate(_slotTemplate, _container);
                _slots.Add(slot);
                slot.gameObject.SetActive(false);
            }
        }
    }
}