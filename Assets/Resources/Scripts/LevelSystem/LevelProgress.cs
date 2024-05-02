using System;
using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class LevelProgress :  CountChanger
    {
        [SerializeField] private RewardWindow _rewardWindow;
        [SerializeField] private ProgressBar _bar;
        [SerializeField] private List<LevelRange> _levelRanges;

        private int _exp = 0;
        private int _level = 1;
        private int _expGoal;

        public event Action LevelChanged;

        public LevelRange CurrentLevelRange { get; private set; }

        private void Awake()
        {
            CurrentLevelRange = _levelRanges[0];
            _expGoal = _levelRanges[0].GoalIncrease;
            UpdateDisplay();
        }

        public void IncreaseExperience(int amount)
        {
            _exp += amount;
            _bar.UpdateBar(amount);

            if (_exp >= _expGoal)
                LevelUp();
        }

        private void LevelUp()
        {
            _level++;
            _exp -= _expGoal;
            int goalIncrease = 0;

            foreach (var levelRange in _levelRanges)
            {
                if (_level >= levelRange.StartLevel && _level <= levelRange.EndLevel)
                {
                    goalIncrease = levelRange.GoalIncrease;

                    if (CurrentLevelRange != levelRange)
                        CurrentLevelRange = levelRange;

                    break;
                }
            }

            LevelChanged?.Invoke();
            _expGoal += goalIncrease;
            UpdateDisplay();
            _rewardWindow.gameObject.SetActive(true);
        }

        private void UpdateDisplay()
        {
            _bar.Set(_expGoal, _exp);
            CountChanged(1);
        }
    }
}