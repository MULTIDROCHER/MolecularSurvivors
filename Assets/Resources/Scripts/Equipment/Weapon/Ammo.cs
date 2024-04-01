using System.Collections;
using DG.Tweening;
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
            /* if (other.gameObject.layer == gameObject.layer)
            { */
                if (other.TryGetComponent(out Enemy enemy))
                    enemy.Health.ApplyDamage(_weapon.GetDamage());

                if (other.TryGetComponent(out BreakableObject breakable))
                    breakable.Health.ApplyDamage(_weapon.GetDamage());
            /* } */
        }

        public void Initialize(Weapon weapon)
        {
            _weapon = weapon;
            SetDuration();
            _renderer = GetComponent<SpriteRenderer>();
            _renderer.color = _weapon.Data.Color;
            gameObject.SetActive(false);
        }

        public IEnumerator Shoot()
        {
            transform.DOScale(new Vector3(2, 2, 2), _weapon.Data.DurationData.Duration / 2);

            yield return _wait;

            transform.DOScale(Vector3.zero, _weapon.Data.DurationData.Duration / 2);
            gameObject.SetActive(false);
        }

        public void SetDuration()
        {
            _wait = new(_weapon.Data.DurationData.Duration);
        }
    }
}