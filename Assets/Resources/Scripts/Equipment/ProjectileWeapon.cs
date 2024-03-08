using UnityEngine;

namespace MolecularSurvivors
{
    public class ProjectileWeapon : Weapon
    {
        protected PlayerMovement PlayerMovement;

        protected override void Start()
        {
            base.Start();
            PlayerMovement = GetComponentInParent<PlayerMovement>();
        }
    }
}
