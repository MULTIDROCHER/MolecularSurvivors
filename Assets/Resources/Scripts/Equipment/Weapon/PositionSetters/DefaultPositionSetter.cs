namespace MolecularSurvivors
{
    public class DefaultPositionSetter : AmmoPositionSetter
    {
        public DefaultPositionSetter(Weapon weapon)
        : base(weapon)
        {
        }

        public override void SetPositions(Ammo[] ammos)
        {
            foreach (var ammo in ammos)
                ammo.transform.localPosition = Weapon.transform.position;
        }
    }
}