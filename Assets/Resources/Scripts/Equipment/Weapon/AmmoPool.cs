using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class AmmoPool
    {
        private List<Ammo> _ammos = new();
        private Weapon _weapon;
        private Ammo _template;
        private int _maxAmount = 10;
        private int _currentAmount;

        public AmmoPool(Weapon weapon, Ammo template, int amount)
        {
            _weapon = weapon;
            _template = template;
            _currentAmount = amount;
        }

        public void CreateAmmos()
        {
            for (int i = 0; i < _maxAmount; i++)
            {
                var ammo = Object.Instantiate(_template, _weapon.transform);
                ammo.Initialize(_weapon);
                _ammos.Add(ammo);
                ammo.gameObject.SetActive(false);
            }
        }

        public Ammo[] GetAmmos()
        {
            var ammos = new Ammo[_currentAmount];

            for (int i = 0; i < ammos.Length; i++)
            {
                if (_ammos[i] != null && _ammos[i].gameObject.activeSelf == false)
                    ammos[i] = _ammos[i];
                else
                    Debug.Log("null ammo at pool");
            }

            return ammos;
        }
    }
}
