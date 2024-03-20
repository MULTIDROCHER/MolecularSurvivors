using UnityEngine;

namespace MolecularSurvivors
{
    public class Ammo : MonoBehaviour
    {
        private Weapon _weapon;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Enemy enemy))
                enemy.Health.Operations.ApplyDamage(_weapon.GetDamage());
        }

        public void Initialize(Weapon weapon)
        {
            _weapon = weapon;
            SetScale();
            gameObject.SetActive(false);
        }

        public void SetScale()
        {
            var size = _weapon.Controller.Stats.AmmoScale;
            var scale = new Vector3(size, size);

            transform.localScale = scale;
        }
    }
}