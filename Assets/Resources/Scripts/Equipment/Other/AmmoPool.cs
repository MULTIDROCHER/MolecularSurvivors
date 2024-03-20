using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class AmmoPool : MonoBehaviour
    {
        private Dictionary<Weapon, Ammo[]> _ammos = new();

        public void AddWeapon(Weapon weapon)
        {
            if (_ammos.ContainsKey(weapon) == false)
                _ammos.Add(weapon, CreateAmmos(weapon));
        }

        public Ammo[] GetAmmos(Weapon weapon)
        {
            if (_ammos.TryGetValue(weapon, out var weaponsAmmos))
            {
                if (weapon.Data.AmountData.MaxAmount == 1)
                {
                    return weaponsAmmos;
                }
                else
                {
                    var availableAmmos = new Ammo[weapon.Data.AmountData.Amount];
                    var availableCount = 0;

                    foreach (var ammo in weaponsAmmos)
                    {
                        if (ammo.gameObject.activeSelf == false)
                        {
                            availableAmmos[availableCount] = ammo;
                            availableCount++;
                        }
                    }

                    return availableAmmos;
                }
            }

            return null;
        }

        private Ammo[] CreateAmmos(Weapon weapon)
        {
            Ammo[] ammos = new Ammo[weapon.Data.AmountData.MaxAmount];

            for (int i = 0; i < ammos.Length; i++)
            {
                var ammo = Instantiate(weapon.Data.Ammo, transform);
                ammo.Initialize(weapon);
                ammos[i] = ammo;
            }

            return ammos;
        }
    }
}
