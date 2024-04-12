using UnityEngine;

namespace MolecularSurvivors
{
    public abstract class AmmoPositionSetter : MonoBehaviour
    {
        protected Weapon Weapon { get; private set; }

        protected virtual void Awake() => Weapon = GetComponentInParent<Weapon>();

        public abstract void SetPositions(Ammo[] ammos);
    }
}