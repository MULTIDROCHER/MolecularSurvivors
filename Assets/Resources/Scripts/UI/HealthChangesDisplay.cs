using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace MolecularSurvivors
{
    public class HealthChangesDisplay : MonoBehaviour
    {
        private List<Health> _healthInstances = new();

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
        }

        public void Subscribe(Health health)
        {
            _healthInstances.Add(health);
            health.HealthChanged += OnDamageTaken;
        }

        public void Remove(Health health)
        {
            _healthInstances.Remove(health);
            health.HealthChanged -= OnDamageTaken;
        }

        private void OnDamageTaken(int amount, Health health)
        {
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