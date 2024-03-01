using UnityEngine;

namespace MolecularSurvivors
{
    public class ProjectileAmmo : Ammo
    {
        protected ProjectileWeapon Weapon;
        protected Vector3 Direction;
        public float LifeTime;

        protected virtual void Start()
        {
            Weapon = GetComponentInParent<ProjectileWeapon>();
            transform.SetParent(null);
            Destroy(gameObject, LifeTime);
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

            if (direction.x < 0 && direction.y == 0)
            {
                scale.x = -scale.x;
                scale.y = -scale.y;
            }
            else if (direction.x == 0 && direction.y < 0)
            {
                scale.y = -scale.y;
            }
            else if (direction.x == 0 && direction.y > 0)
            {
                scale.x = -scale.x;
            }
            else if (direction.x > 0 && direction.y > 0)
            {
                rotation.z = 0;
            }
            else if (direction.x > 0 && direction.y < 0)
            {
                rotation.z = -90;
            }
            else if (direction.x < 0 && direction.y > 0)
            {
                scale.x = -scale.x;
                scale.y = -scale.y;
                rotation.z = -90;
            }
            else if (direction.x < 0 && direction.y < 0)
            {
                scale.x = -scale.x;
                scale.y = -scale.y;
                rotation.z = 0;
            }

            transform.localScale = scale;
            transform.rotation = Quaternion.Euler(rotation);
        }
    }
}
