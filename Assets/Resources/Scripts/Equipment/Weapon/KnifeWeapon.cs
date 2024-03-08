namespace MolecularSurvivors
{
    public class KnifeWeapon : ProjectileWeapon
    {
        protected override void Attack()
        {
            base.Attack();
            var spawned = Instantiate(WeaponData.Ammo.transform, transform);
            spawned.GetComponent<KnifeAmmo>().SetDirection(PlayerMovement.LastMovementVector);
        }
    }
}
