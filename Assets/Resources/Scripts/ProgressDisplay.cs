using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MolecularSurvivors
{
    public class ProgressDisplay : MonoBehaviour
    {
        private readonly float _speed = .5f;

        [SerializeField] private Slider _slider;
        [SerializeField] private TMP_Text _levelDisplay;

        public void UpdateBar(int amount)
        {
            var newValue = _slider.value + amount;
            _slider.DOValue(newValue, _speed);
        }

        public void Set(int goal, int currentValue, int level)
        {
            _slider.maxValue = goal;
            _slider.value = 0;
            UpdateBar(currentValue);
            _levelDisplay.text = level.ToString();
        }
    }
}