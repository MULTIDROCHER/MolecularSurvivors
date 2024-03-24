using System.Collections.Generic;
using System.Linq;
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

        private void Update() => Timer.Update();

        public virtual void Add(T data)
        {
            var equipment = Instantiate(Template, transform);
            equipment.Initialize(data, this);

            Equipment.Add(equipment);
            Timer.Add(equipment);
        }

        private void OnAdded(EquipmentData data)
        {
            if (data is T t)
            {
                var equipment = Equipment.FirstOrDefault(item => item.Data == t);
                
                if (equipment != null)
                    equipment.Data.LevelData.LevelUp();
                else
                    Add(t);
            }
        }

        private void OnReadyToExecute(int index) => Equipment[index].Execute();
    }
}