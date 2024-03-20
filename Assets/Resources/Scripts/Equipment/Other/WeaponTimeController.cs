using System;
using System.Collections.Generic;

namespace MolecularSurvivors
{
    public class WeaponTimeController
    {
        private readonly List<TimerComponent> _timers = new();

        public event Action<int> ReadyToAttack;

        public void Add(Weapon weapon)
        {
            if (_timers.Contains(weapon.Data.TimerData) == false)
                _timers.Add(weapon.Data.TimerData);
        }

        public void Update()
        {
            foreach (var timer in _timers)
                if (timer.ReadyToAttack())
                    ReadyToAttack?.Invoke(_timers.IndexOf(timer));
        }
    }
}