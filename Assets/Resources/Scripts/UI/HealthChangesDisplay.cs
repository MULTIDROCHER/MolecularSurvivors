using System.Collections;
using TMPro;
using UnityEngine;
using Zenject;

namespace MolecularSurvivors
{
    public class HealthChangesDisplay : MonoBehaviour
    {
        //private List<Health> _healthInstances = new();

        [Inject] private HealthEventBus _eventBus;

        [SerializeField] private Canvas _canvas;
        [SerializeField] private TMP_Text _prefab;
        [SerializeField] private int _poolAmount;
        [SerializeField] private float _duration;
        [SerializeField] private Vector3 _offset;

        private WaitForSeconds _wait;
        private ObjectPool<TMP_Text> _textPool;

        private void Awake()
        {
            _textPool = new(_prefab, _poolAmount, _canvas.transform);
            _wait = new(_duration);
            _eventBus.Subscribe<HealthChangedSignal>(DamageTaken);
        }

        private void OnDestroy() => _eventBus.Unsubscribe<HealthChangedSignal>(DamageTaken);

        private void DamageTaken(HealthChangedSignal signal) => OnDamageTaken(signal.Health);

        private void OnDamageTaken(Health health)
        {
            var amount = health.LastChange;
            var text = GetText(amount.ToString(), amount > 0 ? Color.green : Color.red);

            if (text != null)
                StartCoroutine(ShowChange(text, health.Damagable.position));
        }

        private TMP_Text GetText(string text, Color color)
        {
            var display = _textPool.GetObject();

            if (display != null)
            {
                display.text = text;
                display.color = color;
            }

            return display;
        }

        private IEnumerator ShowChange(TMP_Text text, Vector3 position)
        {
            text.transform.localScale = Vector3.one;
            text.transform.parent.position = position + _offset;
            text.gameObject.SetActive(true);
            yield return _wait;
            _textPool.ReturnObject(text);
        }
    }
}