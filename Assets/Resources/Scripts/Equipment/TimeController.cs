using System;
using System.Collections.Generic;

namespace MolecularSurvivors
{
    public class TimeController<T> where T: EquipmentData
    {
        private readonly EquipmentController<T> _controller;

        public event Action<Equipment<T>> ReadyToExecute;

        public TimeController(EquipmentController<T> controller) => _controller = controller;

        public void Update()
        {
            foreach (var equipment in _controller.Equipment)
                if (equipment.Data.TimerData.ReadyToAttack())
                    ReadyToExecute?.Invoke(equipment);
        }
    }
}