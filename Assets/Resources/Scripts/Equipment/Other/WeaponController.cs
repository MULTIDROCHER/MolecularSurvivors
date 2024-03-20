using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class WeaponController : MonoBehaviour
    {
        private readonly WeaponTimeController _timeController = new();

        [field: SerializeField] public EquipmentStats Stats { get; private set; }
        [SerializeField] private AmmoPool _pool;
        [SerializeField] private Weapon _template;

        public List<Weapon> Weapons { get; private set; } = new();

        private void Awake()
        {
            var startWeapon = GetComponentInParent<Player>().PlayerData.StartWeapon;

            AddWeapon(startWeapon);
        }

        private void OnEnable() => _timeController.ReadyToAttack += OnReadyToAttack;

        private void OnDisable() => _timeController.ReadyToAttack -= OnReadyToAttack;

        private void Update() => _timeController.Update();

        public void AddWeapon(WeaponData data)
        {
            var weapon = Instantiate(_template, transform);
            weapon.Initialize(this, _pool, data);
            Weapons.Add(weapon);
            _timeController.Add(weapon);
        }

        private void OnReadyToAttack(int index) => Weapons[index].Execute();
    }
}