using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class WeaponController : MonoBehaviour
    {
        [SerializeField] private AmmoPool _pool;
        //TODO separate timing logic
        public Dictionary<Weapon, TimerComponent> Weapons { get; private set; } = new();

        private void Start()
        {
            var weapons = GetComponentsInChildren<Weapon>();

            foreach (var weapon in weapons)
            {
                AddWeapon(weapon);
            }
        }

        private void Update() => UpdateTimers();

        public void AddWeapon(Weapon weapon)
        {
            if (Weapons.ContainsKey(weapon) == false && weapon.Data.TryGetData(out TimerComponent timer))
            {
                Weapons.Add(weapon, timer);
                weapon.Initialize(_pool);
            }
        }

        private void UpdateTimers()
        {
            foreach (var timer in Weapons)
            {
                if (timer.Value.ReadyToAttack())
                    timer.Key.Attack();
            }
        }
    }
}