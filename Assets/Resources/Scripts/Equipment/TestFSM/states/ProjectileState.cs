using UnityEngine;

namespace MolecularSurvivors
{
    public class ProjectileState : AmmoState
    {
        [Header("Projectile State")]
        private Vector3 _direction;
        private float _speed = 5;

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Projectile State enter");
            _direction = Ammo.GetRandomPosition();
        }

        public override void Update(float deltaTime)
        {
            Debug.Log("Projectile State upd");
            Ammo.transform.Translate(_speed * deltaTime * _direction, Space.World);
            base.Update(deltaTime);
        }
    }
}