using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace MolecularSurvivors
{
    public abstract class EquipmentController<T> : MonoBehaviour where T : EquipmentData
    {
        private Inventory _inventory;

        [SerializeField] private Equipment<T> _template;

        public Player Player { get; private set; }
        private TimeController<T> _timer = new();
        private UpgradesController<T> _upgradesController = new();
        public List<Equipment<T>> Equipment { get; private set; } = new();

        [Inject]
        private void Construct(Player player, Inventory inventory)
        {
            Player = player;
            _inventory = inventory;
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
                var equipment = Equipment.FirstOrDefault(equipment => equipment.Data == controlable);

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