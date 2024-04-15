using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class AmmoPool
    {
        private readonly Weapon _weapon;
        private readonly Ammo _template;
        private int _maxAmount = 20;
        private int _amount;
        private AmountComponent _amountData;

        public List<Ammo> Ammos { get; private set; } = new();

        public AmmoPool(Weapon weapon, Ammo template)
        {
            _weapon = weapon;
            _template = template;
            SetAmount();
        }

        private void SetAmount()
        {
            _amountData = (AmountComponent)_weapon.Data.GetComponent(ComponentType.Amount);

            if (_amountData != null)
            {
                _maxAmount = _amountData.MaxAmount;
                _amount = _amountData.Amount;
            }
            else
            {
                _amount = 1;
                _maxAmount = 1;
            }
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

        public Ammo[] GetAmmos()
        {
            var ammos = new Ammo[_amount];

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