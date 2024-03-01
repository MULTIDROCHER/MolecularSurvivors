using UnityEngine;

namespace MolecularSurvivors
{
    public class AreaWeapon : Weapon
    {
        [SerializeField] private Vector3 _scale = Vector3.one;

        public Vector3 Scale => _scale;
    }
}
