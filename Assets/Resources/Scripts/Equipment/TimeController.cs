using System;
using System.Collections.Generic;

namespace MolecularSurvivors
{
    public class TimeController<T> where T: EquipmentData
    {
        private readonly List<TimerComponent> _timers = new();

        public event Action<int> ReadyToExecute;

        public void Add(Equipment<T> equipment)
        {
            if (_timers.Contains(equipment.Data.TimerData) == false)
                _timers.Add(equipment.Data.TimerData);
        }

        public void Update()
        {
            foreach (var timer in _timers)
                if (timer.ReadyToAttack())
                    ReadyToExecute?.Invoke(_timers.IndexOf(timer));
        }
    }
}