using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace MolecularSurvivors
{
    [RequireComponent(typeof(PlayerHealth))]
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider _bar;
        [SerializeField] private Health _health;

        private readonly float _duration = .5f;

        private void Start()
        {
            _bar.maxValue = _health.MaxAmount;
            OnHealthChanged(_health.Current, _health);
        }

        private void OnEnable() => _health.HealthChanged += OnHealthChanged;

        private void OnDisable() => _health.HealthChanged -= OnHealthChanged;

        private void OnHealthChanged(int value, Health health) => _bar.DOValue(value, _duration, true);
        //todo rewrite event - health is unrequired in this method
    }
}