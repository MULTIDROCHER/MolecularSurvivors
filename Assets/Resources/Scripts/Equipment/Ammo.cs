using UnityEngine;

namespace MolecularSurvivors
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class Ammo : MonoBehaviour
    {
        protected Collider2D Collider;
        protected Weapon Weapon;

        protected virtual void Awake()
        {
            Collider = GetComponent<Collider2D>();
            Weapon = GetComponentInParent<Weapon>();
        }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Enemy enemy) && enemy.Health != null)
                DoDamage(enemy.Health);
        }

        protected virtual void DoDamage(Health health)
        {
            health.Operations.Decrease(Weapon.WeaponData.Damage);
        }
    }
}