using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class AmmoPool
    {
        private readonly Weapon _weapon;
        private readonly Ammo _template;
        private readonly int _maxAmount = 20;

        public List<Ammo> Ammos { get; private set; } = new();

        public AmmoPool(Weapon weapon, Ammo template)
        {
            _weapon = weapon;
            _template = template;
        }

        public void CreateAmmos()
        {
            for (int i = 0; i < _maxAmount; i++)
            {
                var ammo = Object.Instantiate(_template, _weapon.transform);
                ammo.Initialize(_weapon);
                Ammos.Add(ammo);
                ammo.gameObject.SetActive(false);
            }
        }

        public Ammo[] GetAmmos(int amount)
        {
            if (amount > _maxAmount)
                amount = _maxAmount;

            var ammos = new Ammo[amount];

            for (int i = 0; i < ammos.Length; i++)
            {
                if (Ammos[i] != null && Ammos[i].Active == false)
                    ammos[i] = Ammos[i];
                else
                    Debug.Log("null ammo at pool");
            }

            return ammos;
        }
    }
}