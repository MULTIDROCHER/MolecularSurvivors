using UnityEngine;

namespace MolecularSurvivors
{
    public class ProjectileAmmo : Ammo
    {
        protected Vector3 Direction;

        protected override void Awake()
        {
            base.Awake();
        }

        protected virtual void Start()
        {
            transform.SetParent(null);
            Destroy(gameObject, Weapon.WeaponData.EffectDuration);
        }

        public void SetDirection(Vector3 direction)
        {
            Direction = direction;
            Rotate(direction);
        }

        private void Rotate(Vector3 direction)
        {
            Vector3 scale = transform.localScale;
            Vector3 rotation = transform.eulerAngles;

            if (direction.x < 0 && direction.y == 0)//left
            {
                scale.x = -scale.x;
                scale.y = -scale.y;
            }
            else if (direction.x == 0 && direction.y < 0)//down
            {
                scale.y = -scale.y;
            }
            else if (direction.x == 0 && direction.y > 0)//up
            {
                scale.x = -scale.x;
            }
            else if (direction.x > 0 && direction.y > 0)//rightUp
            {
                rotation.z = 0;
            }
            else if (direction.x > 0 && direction.y < 0)//rightDown
            {
                rotation.z = -90;
            }
            else if (direction.x < 0 && direction.y > 0)//leftUp
            {
                scale.x = -scale.x;
                scale.y = -scale.y;
                rotation.z = -90;
            }
            else if (direction.x < 0 && direction.y < 0)//leftDown
            {
                scale.x = -scale.x;
                scale.y = -scale.y;
                rotation.z = 0;
            }

            transform.localScale = scale;
            transform.rotation = Quaternion.Euler(rotation);
        }

        protected override void DoDamage(Health health)
        {
            base.DoDamage(health);
            Destroy(gameObject);
        }
    }
}