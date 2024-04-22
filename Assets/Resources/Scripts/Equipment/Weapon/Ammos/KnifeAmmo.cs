using UnityEngine;

namespace MolecularSurvivors
{
    public class KnifeAmmo : ProjectileAmmo
    {
        protected override Vector3 SetDirection()
        {
            var direction = Weapon.Controller.Player.PlayerMovement.LastMovementVector;
            transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);

            return direction;
        }
    }
}