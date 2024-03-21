using System.Collections;
using UnityEngine;

namespace MolecularSurvivors
{
    public class Ammo : MonoBehaviour
    {
        private SpriteRenderer _renderer;
        private Weapon _weapon;
        private WaitForSeconds _wait;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Enemy enemy))
                enemy.Health.Operations.ApplyDamage(_weapon.GetDamage());
        }

        public void Initialize(Weapon weapon)
        {
            _weapon = weapon;
            SetScale();
            SetDuration();
            _renderer = GetComponent<SpriteRenderer>();
            _renderer.color = _weapon.Data.Color;
            gameObject.SetActive(false);
        }

        public IEnumerator Shoot()
        {
            transform.localPosition = Vector3.zero;

            yield return _wait;

            gameObject.SetActive(false);
        }

        public void SetScale()
        {
            //todo change scale
            var size = 2;
            var scale = new Vector3(size, size);

            transform.localScale = scale;
        }

        public void SetDuration()
        {
            _wait = new(_weapon.Data.DurationData.Duration);
        }
    }
}