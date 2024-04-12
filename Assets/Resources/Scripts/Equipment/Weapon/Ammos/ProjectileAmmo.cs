using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace MolecularSurvivors
{
    public abstract class ProjectileAmmo : Ammo
    {
        [SerializeField] private int _collisionsCount = 1;
        private Vector3 _direction;
        private float _speed;
        private Transform _parent;
        private int _collisions = 0;

        public override void Initialize(Weapon weapon)
        {
            _parent = transform.parent;
            base.Initialize(weapon);
        }

        public override void Activate()
        {
            _speed = Weapon.SetSpeed();
            _direction = SetDirection();
            _collisions = 0;

            transform.SetParent(null);
            base.Activate();
        }

        public override void Deactivate()
        {
            transform.SetParent(_parent);
            base.Deactivate();
        }

        private void Update() => Move();

        protected virtual void Move()
        {
            transform.position += _speed * Time.deltaTime * _direction;
            //transform.Translate(_speed * Time.deltaTime * _direction);
        }

        protected abstract Vector3 SetDirection();

        protected override void OnDamagableEnter(IDamagable damagable)
        {
            base.OnDamagableEnter(damagable);
            _collisions++;

            if (_collisions >= _collisionsCount)
                Deactivate();
        }
    }
}
