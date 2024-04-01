using UnityEngine;
using UnityEngine.UI;

namespace MolecularSurvivors
{
    public class ProgressBar : MonoBehaviour
    {
        //private readonly float _speed = .5f;

        [SerializeField] private Slider _slider;

        public void UpdateBar(int amount)
        {
            //var newValue = _slider.value + amount;
            //_slider.DOValue(newValue, _speed);
            _slider.value += amount;
        }

        public void Set(int goal, int currentValue)
        {
            _slider.maxValue = goal;
            _slider.value = 0;
            UpdateBar(currentValue);
        }
    }
}