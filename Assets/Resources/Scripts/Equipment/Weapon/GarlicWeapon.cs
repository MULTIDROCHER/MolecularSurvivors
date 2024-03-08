namespace MolecularSurvivors
{
    public class GarlicWeapon : Weapon
    {
        private GarlicAmmo _spawned;

        protected override void Start()
        {
            base.Start();
            _spawned = Instantiate(WeaponData.Ammo.gameObject, transform).GetComponent<GarlicAmmo>();
        }

        protected override void Attack()
        {
            base.Attack();
            _spawned.Activate();
        }
    }
}
