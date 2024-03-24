using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace MolecularSurvivors
{
    [RequireComponent(typeof(CharactersHealth))]
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Slider _bar;
        [SerializeField] private Health _health;

        private readonly float _duration = .5f;

        private void Start()
        {
            _bar.maxValue = _health.MaxAmount;
            OnHealthChanged(_health.Current);
        }

        private void OnEnable() => _health.HealthChanged += OnHealthChanged;

        private void OnDisable() => _health.HealthChanged -= OnHealthChanged;

        private void OnHealthChanged(int value) => _bar.DOValue(value, _duration, true);
    }
}