using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class Weapon : Equipment<WeaponData>
    {
        private List<Ammo> _ammos = new();

        public override void Initialize(WeaponData data, EquipmentController<WeaponData> controller)
        {
            base.Initialize(data, controller);
            CreateAmmos();
        }

        public override void Execute()
        {
            var ammos = GetAmmos();

            foreach (var ammo in ammos)
            {
                if (ammo != null)
                {
                    ammo.gameObject.SetActive(true);
                    ammo.StartCoroutine(ammo.Shoot());
                }
                else
                    Debug.Log("null ammo");
            }
        }

        private Ammo[] GetAmmos()
        {
            var ammos = new Ammo[Data.AmountData.Amount];

            for (int i = 0; i < ammos.Length; i++)
            {
                if (_ammos[i].gameObject.activeSelf == false)
                    ammos[i] = _ammos[i];
            }

            return ammos;
        }

        public int GetDamage() => Data.DamageData.Damage;

        private void CreateAmmos()
        {
            int maxAmount = Data.AmountData.MaxAmount;

            for (int i = 0; i < maxAmount; i++)
            {
                var ammo = Instantiate(Data.Ammo, transform);
                ammo.Initialize(this);
                _ammos.Add(ammo);
            }
        }
    }
}