using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

namespace MolecularSurvivors
{
    public class HealthChangesDisplay : MonoBehaviour
    {
        [SerializeField] private HealthOperations _operations;
        [SerializeField] private Canvas _prefab;
        [SerializeField] private int _poolAmount;
        [SerializeField] private float _duration;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private bool _showDecrease;

        private TMP_Text[] _pool;
        private int _health;
        private WaitForSeconds _wait;

        private void Awake()
        {
            _health = _operations.MaxAmount;

            _wait = new(_duration);
            Initialize();
        }

        private void OnEnable() => _operations.HealthChanged += OnHealthChanged;

        private void OnDisable() => _operations.HealthChanged -= OnHealthChanged;

        private void OnHealthChanged(int value)
        {
            if (_operations.Current > _health)
                OnIncreased(value);
            else if (_operations.Current < _health && _showDecrease)
                OnDecreased(value);

            _health = _operations.Current;
        }

        private void OnIncreased(int value)
        {
            var text = GetText("+" + value.ToString(), Color.green);

            if (text != null)
                StartCoroutine(ShowChange(text));
        }

        private void OnDecreased(int value)
        {
            var text = GetText(value.ToString(), Color.red);

            if (text != null)
                StartCoroutine(ShowChange(text));
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

        private IEnumerator ShowChange(TMP_Text text)
        {
            Debug.Log(text.text);
            text.transform.localScale = Vector3.one;
            text.gameObject.SetActive(true);
            yield return _wait;
            text.gameObject.SetActive(false);
        }

        private void Initialize()
        {
            _pool = new TMP_Text[_poolAmount];

            for (int i = 0; i < _poolAmount; i++)
            {
                var display = Instantiate(_prefab, transform.position + _offset, Quaternion.identity, transform);
                var text = display.GetComponentInChildren<TMP_Text>();
                text.gameObject.SetActive(false);
                _pool[i] = text;
            }
        }
    }
}