using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class Weapon : Equipment<WeaponData>
    {
        private AmmoPool _pool;

        public override void Initialize(WeaponData data, EquipmentController<WeaponData> controller)
        {
            base.Initialize(data, controller);
            _pool = new(this, Data.AmmoData.Template, Data.AmountData.MaxAmount);
            _pool.CreateAmmos();
        }

        public override void Execute()
        {
            var ammos = _pool.GetAmmos();

            foreach (var ammo in ammos)
            {
                if (ammo != null)
                {
                    ammo.Activate();
                }
                else
                    Debug.Log("null ammo at weapon");
            }
        }

        public int GetDamage() => Data.DamageData.Damage;
    }
}