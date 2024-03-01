using UnityEngine;

namespace MolecularSurvivors
{
    public class KnifeWeapon : ProjectileWeapon
    {
        [SerializeField] protected KnifeAmmo Prefab;
        protected override void Start()
        {
            base.Start();
        }

        protected override void Attack()
        {
            base.Attack();
            var spawned = Instantiate(Prefab.transform, transform);
            spawned.GetComponent<KnifeAmmo>().SetDirection(PlayerMovement.LastMovementVector);
        }
    }
}
