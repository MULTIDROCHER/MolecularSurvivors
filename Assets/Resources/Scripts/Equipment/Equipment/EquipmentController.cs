using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace MolecularSurvivors
{
    public abstract class EquipmentController<T> : MonoBehaviour where T : EquipmentData
    {
        [SerializeField] private Equipment<T> _template;
        
        private Inventory _inventory;
        private TimeController<T> _timer;
        private UpgradesController<T> _upgradesController;

        public Player Player { get; private set; }
        public List<Equipment<T>> Equipment { get; private set; } = new();

        [Inject]
        private void Construct(Player player, Inventory inventory)
        {
            Player = player;
            _inventory = inventory;
        }

        private void Awake(){
            _timer = new(this);
            _upgradesController = new(this);
        }

        private void OnEnable()
        {
            _inventory.EquipmentAdded += OnAdded;
            _timer.ReadyToExecute += OnReadyToExecute;
        }

        private void OnDisable()
        {
            _inventory.EquipmentAdded -= OnAdded;
            _timer.ReadyToExecute -= OnReadyToExecute;
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
        }

        private void OnReadyToExecute(Equipment<T> equipment) => equipment.Execute();
    }
}