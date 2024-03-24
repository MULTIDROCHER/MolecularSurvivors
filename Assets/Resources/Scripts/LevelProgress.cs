using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MolecularSurvivors
{
    public class LevelProgress : MonoBehaviour
    {
        [SerializeField] private RewardWindow _rewardWindow;
        [SerializeField] private ProgressDisplay _display;
        [SerializeField] private List<LevelRange> _levelRanges;

        private int _exp = 0;
        private int _level = 1;
        private int _expGoal;

        private void Start()
        {
            _expGoal = _levelRanges[0].GoalIncrease;
            _display.Set(_expGoal, _exp, _level);
        }

        public void IncreaseExperience(int amount)
        {
            _exp += amount;
            _display.UpdateBar(amount);

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
                    break;
                }
            }

            _expGoal += goalIncrease;
            _display.Set(_expGoal, _exp, _level);
            _rewardWindow.gameObject.SetActive(true);
        }
    }
}