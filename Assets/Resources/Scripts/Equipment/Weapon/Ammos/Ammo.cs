using System.Collections;
using UnityEditor;
using UnityEngine;

namespace MolecularSurvivors
{
    public class Ammo : MonoBehaviour
    {
        public bool Active { get; protected set; } = false;
        public Weapon Weapon { get; private set; }
        private int _damage;

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IDamagable damagable))
                if (damagable == (IDamagable)Weapon.Controller.Player)
                    return;
                else
                    OnDamagableEnter(damagable);
        }

        public virtual void Initialize(Weapon weapon) => Weapon = weapon;

        public virtual void Activate()
        {
            _damage = Weapon.SetDamage();
            gameObject.SetActive(true);
            Active = true;
        }

        public virtual void Deactivate()
        {
            gameObject.SetActive(false);
            Active = false;
        }

        protected virtual void OnDamagableEnter(IDamagable damagable)
        {
            damagable.ApplyDamage(_damage);
        }
    }
}