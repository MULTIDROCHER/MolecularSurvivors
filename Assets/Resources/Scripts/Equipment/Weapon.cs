using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class Weapon : Equipment<WeaponData>
    {
        private AmmoPool _pool;

        public WeaponController Controller { get; private set; }
        public WeaponData Data { get; private set; }

        public void Initialize(WeaponController controller, AmmoPool pool, WeaponData data)
        {
            print("initialized");
            Data = data;
            Controller = controller;

            _pool = pool;
            _pool.AddWeapon(this);
        }

        public override void Execute()
        {
            var ammos = _pool.GetAmmos(this);

            foreach (var ammo in ammos)
            {
                if (ammo != null)
                    ammo.gameObject.SetActive(true);
                else
                    Debug.Log("ammo is null");
            }
        }

        public int GetDamage() => Data.DamageData.Damage + Controller.Stats.Damage;
    }
}