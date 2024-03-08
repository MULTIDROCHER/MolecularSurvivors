using System.Collections;
using UnityEngine;

namespace MolecularSurvivors
{
    public class GarlicAmmo : Ammo
    {
        private WaitForSeconds _duration;

        protected override void Awake()
        {
            base.Awake();
            _duration = new(Weapon.WeaponData.EffectDuration);
            transform.localScale = Weapon.WeaponData.Scale;
        }

        public void Activate()
        {
            gameObject.SetActive(true);
            StartCoroutine(Deactivate());
        }

        private IEnumerator Deactivate()
        {
            yield return _duration;
            gameObject.SetActive(false);
        }
    }
}