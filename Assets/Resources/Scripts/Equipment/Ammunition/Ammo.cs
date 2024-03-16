using System.Collections;
using UnityEngine;

namespace MolecularSurvivors
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class Ammo : MonoBehaviour
    {
        public WeaponData Weapon { get; private set; }

        public virtual void Initialize(Weapon weapon)
        {
            Weapon = weapon.Data;
            gameObject.name = Weapon.TextData.Name;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out Enemy enemy))
                DoDamage(enemy.Health, Weapon.DamageData.GetDamage());
        }

        public virtual void DoDamage(Health health, int damage)
        {
            health.ApplyDamage(damage);
        }

        public abstract void Activate();
    }
}