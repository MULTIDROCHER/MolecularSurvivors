using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MolecularSurvivors
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private TMP_Text _levelDisplay;
        ///to clean
        public int _exp = 0;
        public int _level = 1;
        public int _expGoal = 10;
        public List<LevelRange> _levelRanges;

        private void Start()
        {
            _expGoal = _levelRanges[0]._expGoalIncrease;
            SetSlider();
        }

        public void IncreaseExperience(int amount)
        {
            _exp += amount;
            _slider.DOValue(_exp, .5f);

            CheckLevelUp();
        }

        private void SetSlider()
        {
            _slider.maxValue = _expGoal;
            _slider.value = _exp;
            _levelDisplay.text = _level.ToString();
        }

        private void CheckLevelUp()
        {
            if (_exp >= _expGoal)
            {
                _level++;
                _exp -= _expGoal;
                //_expGoal += _expGoalIncrease;
                int expCapIncrease = 0;

                foreach (var level in _levelRanges)
                {
                    if (_level >= level._startLevel && _level <= level._endLevel)
                    {
                        expCapIncrease = level._expGoalIncrease;
                        break;
                    }
                }

                _expGoal += expCapIncrease;
                SetSlider();
            }
        }
    }

    [Serializable]
    public class LevelRange
    {
        public int _startLevel;
        public int _endLevel;
        public int _expGoalIncrease;
    }
}
