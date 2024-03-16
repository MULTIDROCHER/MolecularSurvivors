using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace MolecularSurvivors
{
    public class AreaAmmo : Ammo
    {
        private AreaComponent _areaComponent;
        private DurationComponent _durationComponent;
        private WaitForSeconds _wait;
        private Vector3 _deactivated = new(.1f, .1f);

        private Vector3 _scale => _areaComponent.AreaScale;
        private float _duration => _durationComponent.GetDuration();

        public override void Initialize(Weapon weapon)
        {
            base.Initialize(weapon);
            _areaComponent = Weapon.RequireComponent<AreaComponent>();
            _durationComponent = Weapon.RequireComponent<DurationComponent>();

            transform.localScale = _scale;
            _wait = new WaitForSeconds(_duration);
        }

        public override void Activate()
        {
            transform.DOScale(_scale, 1f);
            StartCoroutine(Deactivate());
        }

        private IEnumerator Deactivate()
        {
            yield return _wait;
            transform.DOScale(_deactivated, 1f);
        }
    }
}