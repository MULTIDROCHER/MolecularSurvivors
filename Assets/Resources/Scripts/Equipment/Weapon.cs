using UnityEngine;

namespace MolecularSurvivors
{
    public abstract class Weapon : MonoBehaviour
    {
        [SerializeField] private WeaponData _weaponData;

        private float _cooldown;
        private PlayerData _player;

        public WeaponData WeaponData => _weaponData;
        public float Speed => _weaponData.Speed + _player.ProjectileSpeed;

        protected virtual void Start()
        {
            _player = GetComponentInParent<Player>().PlayerData;
            _cooldown = WeaponData.Cooldown;

            Debug.Log(WeaponData.Name);
        }

        protected virtual void Update()
        {
            _cooldown -= Time.deltaTime;

            if (_cooldown <= 0)
                Attack();
        }

        protected virtual void Attack()
        {
            _cooldown = WeaponData.Cooldown;
        }
    }
}