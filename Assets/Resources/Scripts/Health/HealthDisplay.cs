using MoreMountains.Tools;
using UnityEngine;

namespace MolecularSurvivors
{
    [RequireComponent(typeof(MMHealthBar))]
    [RequireComponent(typeof(HealthOperations))]
    public class HealthDisplay : MonoBehaviour
    {
        private HealthOperations _operations;
        private MMHealthBar _bar;
        private int _maxvalue;

        private void Awake()
        {
            _operations = GetComponent<HealthOperations>();
            _maxvalue = _operations.MaxAmount;
            _bar = GetComponent<MMHealthBar>();
        }

        private void OnEnable() => _operations.HealthChanged += UpdateBar;

        private void OnDisable() => _operations.HealthChanged -= UpdateBar;

        private void UpdateBar(int currentValue) => _bar.UpdateBar(currentValue, 0, _maxvalue, true);
    }
}