using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace MolecularSurvivors
{
    public class ProjectileAmmo : Ammo
    {
        private Weapon _weapon;
        private float _duration;
        private PlayerMovement _movement;

        public override void Initialize(Weapon weapon)
        {
            base.Initialize(weapon);
            _weapon = weapon;
            _duration = Weapon.RequireComponent<DurationComponent>().GetDuration();
            _movement = _weapon.transform.GetComponentInParent<PlayerMovement>();
        }

        public override void Activate()
        {
            transform.position = _weapon.transform.position;

            Vector3 direction = _movement.LastMovementVector.normalized;
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = rotation;

            transform.DOMove(transform.forward, _duration).OnComplete(() => gameObject.SetActive(false));
        }
    }
}
