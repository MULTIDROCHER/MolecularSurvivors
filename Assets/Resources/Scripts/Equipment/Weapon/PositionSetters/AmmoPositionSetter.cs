namespace MolecularSurvivors
{
    public abstract class AmmoPositionSetter
    {
        protected Weapon Weapon { get; private set; }

        public AmmoPositionSetter(Weapon weapon) => Weapon = weapon;

        public abstract void SetPositions(Ammo[] ammos);
    }

    public enum AmmoPositionType
    {
        Default,
        Whip,
        FromRandomPoint,
    }
}