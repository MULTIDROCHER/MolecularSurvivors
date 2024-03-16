using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class Weapon : MonoBehaviour
    {
        [field: SerializeField] public WeaponData Data { get; private set; }

        protected AmmoPool Pool;

        public void Initialize(AmmoPool pool)
        {
            Pool = pool;
            Pool.AddWeapon(this);
        }

        public virtual void Attack()
        {
            var ammos = Pool.GetAmmosToAttack(this);

            foreach (var ammo in ammos)
            {
                if (ammo != null)
                {
                    ammo.gameObject.SetActive(true);
                    ammo.Activate();
                }else{
                    Debug.Log($"ammos is {ammos != null} and ammos amount = {ammos.Length}");
                }
            }
        }
    }
}