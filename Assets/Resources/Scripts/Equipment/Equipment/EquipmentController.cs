using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public abstract class EquipmentController<T> : MonoBehaviour where T : EquipmentData
    {
        [field: SerializeField] public Player Player { get; private set; }
        [SerializeField] protected Equipment<T> Template;
        [SerializeField] private Inventory _inventory;

        protected TimeController<T> Timer = new();
        protected List<Equipment<T>> Equipment = new();

        private void OnEnable()
        {
            Timer.ReadyToExecute += OnReadyToExecute;
            _inventory.EquipmentAdded += OnAdded;
        }

        private void OnDisable()
        {
            Timer.ReadyToExecute -= OnReadyToExecute;
            _inventory.EquipmentAdded -= OnAdded;
        }

        private void OnAdded(EquipmentData data)
        {
            if (data is T t)
                Add(t);
        }


        private void Update() => Timer.Update();

        public virtual void Add(T data)
        {
            var equipment = Instantiate(Template, transform);
            equipment.Initialize(data, this);

            Equipment.Add(equipment);
            Timer.Add(equipment);
        }

        private void OnReadyToExecute(int index) => Equipment[index].Execute();
    }
}