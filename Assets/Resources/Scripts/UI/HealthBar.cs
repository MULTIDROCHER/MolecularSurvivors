using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace MolecularSurvivors
{
    public class HealthBar : MonoBehaviour
    {
        private readonly float _duration = .5f;
        private Health _health;

        [SerializeField] private Slider _bar;

        private HealthEventBus _eventBus;

        public void Set(Health health, HealthEventBus eventBus)
        {
            _health = health;
            _bar.maxValue = health.MaxAmount;
            UpdateBar();

            _eventBus = eventBus;
            _eventBus.Subscribe<HealthChangedSignal>(OnHealthChanged);
        }

        private void OnDisable() => _eventBus.Unsubscribe<HealthChangedSignal>(OnHealthChanged);

        private void OnHealthChanged(HealthChangedSignal health)
        {
            if (health.Health == _health)
                UpdateBar();
        }

        private void UpdateBar() => _bar.DOValue(_health.Current, _duration, true);
    }
}