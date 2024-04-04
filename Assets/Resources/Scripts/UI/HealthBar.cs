using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace MolecularSurvivors
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider _bar;
        private CharacterHealth _health;

        private readonly float _duration = .5f;

        public void Set(CharacterHealth health)
        {
            _health = health;
            _bar.maxValue = _health.MaxAmount;
            OnHealthChanged(_health.Current, _health);
            _health.HealthChanged += OnHealthChanged;
        }

        private void OnDisable() => _health.HealthChanged -= OnHealthChanged;

        private void OnHealthChanged(int value, Health health) => _bar.DOValue(_health.Current, _duration, true);
        //todo rewrite event - properties are unrequired in this method
    }
}