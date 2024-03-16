using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class AmmoPool : MonoBehaviour
    {
        public Dictionary<Weapon, Ammo[]> Ammos { get; private set; } = new();

        private AmountComponent _amountComponent;

        public void AddWeapon(Weapon weapon)
        {
            if (Ammos.ContainsKey(weapon) == false)
                Ammos.Add(weapon, CreateAmmos(weapon));
        }

        public Ammo[] GetAmmosToAttack(Weapon weapon)
        {
            Ammo[] ammos;

            if (weapon.Data.TryGetData(out AmountComponent data))
            {
                ammos = new Ammo[data.Amount];

                for (int i = 0; i < ammos.Length; i++)
                {
                    if (Ammos[weapon][i].gameObject.activeSelf == false)
                        ammos[i] = Ammos[weapon][i];
                }

                return ammos;
            }
            else
            {
                return Ammos[weapon];
            }
        }

        private Ammo[] CreateAmmos(Weapon weapon)
        {
            int amount;

            if (weapon.Data.TryGetData(out _amountComponent))
                amount = _amountComponent.MaxAmount;
            else
                amount = 1;

            Ammo[] ammos = new Ammo[amount];

            for (int i = 0; i < ammos.Length; i++)
            {
                var ammo = Instantiate(weapon.Data.Ammo, transform);
                ammo.Initialize(weapon);
                ammo.gameObject.SetActive(false);
                ammos[i] = ammo;
            }

            _amountComponent = null;

            return ammos;
        }
    }
}