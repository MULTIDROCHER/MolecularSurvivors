using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class RewardWindow : MonoBehaviour
    {
        private readonly TimeControl _timeController = new();
        private readonly List<RewardSlot> _slots = new();

        [SerializeField] private int _slotsAmount;
        [SerializeField] private Transform _container;
        [SerializeField] private RewardSlot _slotTemplate;
        [SerializeField] private DefaultReward[] _defaultRewards;
        [SerializeField] private Player _player;
        [SerializeField] private ParticleSystem _rewardEffect;

        private RewardSlotsLoader _loader;

        private void Awake()
        {
            Initialize();
            _loader = new(_player.Inventory, _slots, _defaultRewards);
            _slots.ForEach(slot => slot.RewardSelected += RewardSelected);
        }

        private void OnEnable()
        {
            _loader.LoadSlots();
            _timeController.StopTime();
            _rewardEffect.Play();
        }

        private void OnDisable()
        {
            _loader.Reset();
            _timeController.StartTime();
            _rewardEffect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }

        private void OnDestroy()
        {
            _loader.OnDestroy();
            _slots.ForEach(slot => slot.RewardSelected -= RewardSelected);
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

        private void RewardSelected(IReward data)
        {
            switch (data)
            {
                case EquipmentReward equipment:
                    _player.Inventory.Add(equipment.Data);
                    break;
                case DefaultReward common:
                    _player.ResourceHandler.GetLoot(common.Loot);
                    break;
                default:
                    throw new System.Exception("Unknown reward type");
            }

            gameObject.SetActive(false);
        }
    }
}