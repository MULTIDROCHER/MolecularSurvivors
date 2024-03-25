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

        [SerializeField] private Canvas _prefab;
        [SerializeField] private int _poolAmount;
        [SerializeField] private float _duration;
        [SerializeField] private Vector3 _offset;

        private TMP_Text[] _pool;
        private WaitForSeconds _wait;

        private void Awake()
        {
            _wait = new(_duration);
            Initialize();
        }

        public void Subscribe(CharacterHealth health)
        {
            _healthInstances.Add(health);
            health.DamageTaken += OnDamageTaken;
        }

        public void Remove(CharacterHealth health)
        {
            _healthInstances.Remove(health);
            health.DamageTaken -= OnDamageTaken;
        }

        private void OnDamageTaken(string value, Vector3 position)
        {
            var text = GetText(value, Color.white);

            if (text != null)
                StartCoroutine(ShowChange(text, position));
        }

        private TMP_Text GetText(string text, Color color)
        {
            var display = _pool.FirstOrDefault(text => text.gameObject.activeSelf == false);

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
            text.transform.parent.localPosition = position;
            text.gameObject.SetActive(true);
            yield return _wait;
            text.gameObject.SetActive(false);
        }

        private void Initialize()
        {
            _pool = new TMP_Text[_poolAmount];

            for (int i = 0; i < _poolAmount; i++)
            {
                var display = Instantiate(_prefab, transform);
                var text = display.GetComponentInChildren<TMP_Text>();
                text.gameObject.SetActive(false);
                _pool[i] = text;
            }
        }
    }
}