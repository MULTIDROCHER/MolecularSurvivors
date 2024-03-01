using System.Collections;
using UnityEngine;

namespace MolecularSurvivors
{
    public class GarlicAmmo : Ammo
    {
        private GarlicWeapon _weapon;
        private WaitForSeconds _duration;
        private SpriteRenderer _renderer;

        protected override void Awake()
        {
            base.Awake();
            _weapon = GetComponentInParent<GarlicWeapon>();
            _duration = new(_weapon.Duration);
            transform.localScale = _weapon.Scale;
            _renderer = GetComponent<SpriteRenderer>();
        }

        public void Activate()
        {
            Collider.enabled = true;
            _renderer.color = Color.white;
            StartCoroutine(Deactivate());
        }

        private IEnumerator Deactivate()
        {
            yield return _duration;

            Collider.enabled = false;
            _renderer.color = Color.red;
        }
    }
}