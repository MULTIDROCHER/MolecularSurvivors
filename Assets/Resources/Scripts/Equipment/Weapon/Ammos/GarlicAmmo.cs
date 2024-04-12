using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class GarlicAmmo : Ammo
    {
        private Collider2D _collider;

        public override void Initialize(Weapon weapon)
        {
            _collider = GetComponent<Collider2D>();
            base.Initialize(weapon);
        }

        public override void Activate()
        {
            base.Activate();
            _collider.enabled = true;
        }

        public override void Deactivate()
        {
            Active = false;
            _collider.enabled = false;
        }

        /* protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);

            if (other.TryGetComponent(out Enemy enemy))
                //enemy.GetComponent<Rigidbody2D>().AddForce((enemy.transform.position - transform.position).normalized * 10, ForceMode2D.Impulse);
        } */

    }
}
