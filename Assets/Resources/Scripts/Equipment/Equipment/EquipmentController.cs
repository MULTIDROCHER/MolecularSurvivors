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
        private UpgradesController<T> _upgradesController;
        public List<Equipment<T>> Equipment { get; private set; } = new();

        private Inventory _inventory;

        private void Awake(){
            _inventory = Player.Inventory;
            _upgradesController = new (this);
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
                var equipment = Equipment.FirstOrDefault(item => item.Data == controlable);

                if (equipment != null)
                    _upgradesController.Upgrade(equipment);
                else
                    Add(controlable);
            }
        }

        private void Add(T data)
        {
            var equipment = Instantiate(_template, transform);
            equipment.Initialize(data, this);

            Equipment.Add(equipment);
            _timer.Add(equipment);
            _upgradesController.Add(equipment);
        }

        private void OnReadyToExecute(int index) => Equipment[index].Execute();
    }
}