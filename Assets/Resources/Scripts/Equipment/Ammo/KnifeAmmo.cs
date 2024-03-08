using UnityEngine;

namespace MolecularSurvivors
{
    public class KnifeAmmo : ProjectileAmmo
    {
        private void Update()
        {
            transform.position += Weapon.Speed * Time.deltaTime * Direction;
        }
    }
}