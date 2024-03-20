using UnityEngine;

namespace MolecularSurvivors
{
    [CreateAssetMenu(menuName = "Characters/Player")]
    public class PlayerData : CharacterData
    {
        [SerializeField] private float _recovery;
        [SerializeField] private float _projectileSpeed;
        [SerializeField] private WeaponData _startWeapon;

        public int Level { get; private set; } = 1;

        public float Recovery => _recovery;

        public float ProjectileSpeed => _projectileSpeed;

        public WeaponData StartWeapon => _startWeapon;
    }
}