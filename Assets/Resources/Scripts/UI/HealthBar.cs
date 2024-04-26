using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace MolecularSurvivors
{
    public class HealthBar : MonoBehaviour
    {
        private readonly float _duration = .5f;
        
        [SerializeField] private Slider _bar;

        private EventBus _eventBus;

        public void Set(CharacterHealth health, EventBus eventBus)
        {
            _bar.maxValue = health.MaxAmount;

            _eventBus = eventBus;
            _eventBus?.Subscribe<HealthChangedSignal>(OnHealthChanged);
        }

        private void OnDisable() => _eventBus?.Unsubscribe<HealthChangedSignal>(OnHealthChanged);

        private void OnHealthChanged(HealthChangedSignal health)
        {
            _bar.DOValue(health.Health.Current, _duration, true);
        }
    }
}