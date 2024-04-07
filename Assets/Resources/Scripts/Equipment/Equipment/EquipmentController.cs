using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MolecularSurvivors
{
    public abstract class EquipmentController<T> : MonoBehaviour where T : EquipmentData
    {
        [field: SerializeField] public Player Player { get; private set; }
        [SerializeField] private Equipment<T> _template;

        private TimeController<T> _timer = new();
        private List<Equipment<T>> _equipment = new();

        private Inventory _inventory;

        private void Awake()
        {
            _inventory = Player.Inventory;
        }

        private void OnEnable()
        {
            _timer.ReadyToExecute += OnReadyToExecute;
            _inventory.EquipmentAdded += OnAdded;
        }

        private void OnDisable()
        {
            _timer.ReadyToExecute -= OnReadyToExecute;
            _inventory.EquipmentAdded -= OnAdded;
        }

        private void Update() => _timer.Update();

        private void OnAdded(EquipmentData data)
        {
            if (data is T controlable)
            {
                var equipment = _equipment.FirstOrDefault(item => item.Data == controlable);

                if (equipment != null)
                    equipment.Data.LevelData.LevelUp();
                else
                    Add(controlable);
            }
        }

        private void Add(T data)
        {
            var equipment = Instantiate(_template, transform);
            equipment.Initialize(data, this);

            _equipment.Add(equipment);
            _timer.Add(equipment);
        }

        private void OnReadyToExecute(int index) => _equipment[index].Execute();
    }
}