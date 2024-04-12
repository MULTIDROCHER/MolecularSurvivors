using UnityEngine;

namespace MolecularSurvivors
{
    public class TargetShootAmmo : ProjectileAmmo
    {
        [SerializeField] private bool _randomTarget = false;

        protected override Vector3 SetDirection()
        {
            var target = _randomTarget ? Weapon.Controller.GetRandomEnemy() : Weapon.Controller.GetNearestEnemy();

            if (target == null)
                return Vector3.zero;
            else
                return (target.transform.position - transform.position).normalized;
        }
    }
}