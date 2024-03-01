using UnityEngine;

namespace MolecularSurvivors
{
    public class ProjectileWeapon : Weapon
    {
        [SerializeField] private float _speed;

        public float Speed => _speed;
    }
}
