using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class RewardWindow : MonoBehaviour
    {
        [SerializeField] private int _amount;
        [SerializeField] private Transform _container;
        [SerializeField] private RewardSlot _template;
        [SerializeField] private Inventory _inventory;
        [SerializeField] private EquipmentAssets _assets;

        private List<RewardSlot> _slots = new();

        public Inventory Inventory => _inventory;

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
        }

        public void RewardSelected(EquipmentData data)
        {
            //todo rewrite for event
            _inventory.Add(data);
            gameObject.SetActive(false);
        }

        private void LoadRewards()
        {
            if (_inventory.IsFull)
            {
                Debug.Log("inventory full");
                gameObject.SetActive(false);
                return;
            }

            for (int i = 0; i < _amount; i++)
            {
                var reward = _assets.GetRandomEquipment();

                while (_inventory.HasEquipment(reward))
                    reward = _assets.GetRandomEquipment();

                var slot = _slots[i];
                slot.Set(reward);
                slot.gameObject.SetActive(true);
                Debug.Log(i);
            }
        }


        private void Initialize()
        {
            for (int i = 0; i < _amount; i++)
            {
                var slot = Instantiate(_template, _container);
                _slots.Add(slot);
                slot.gameObject.SetActive(false);
            }
        }
    }
}