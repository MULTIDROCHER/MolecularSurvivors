using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MolecularSurvivors
{
    public class RewardWindow : MonoBehaviour
    {
        private readonly List<RewardSlot> _slots = new();

        [SerializeField] private int _slotsAmount;
        [SerializeField] private Transform _container;
        [SerializeField] private RewardSlot _slotTemplate;
        [SerializeField] private ParticleSystem _rewardEffect;

        private Player _player;
        private TimeControl _timeController;
        private RewardSlotsLoader _loader;

        [Inject]
        private void Construct(Player player, TimeControl timer)
        {
            _player = player;
            _timeController = timer;
        }

        private void Awake()
        {
            Initialize();
            _loader = new(_slots, _player.Inventory);
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
                    _player.LootCollector.GetLoot(common.Loot);
                    break;
                default:
                    throw new System.Exception("Unknown reward type");
            }

            gameObject.SetActive(false);
        }
    }
}