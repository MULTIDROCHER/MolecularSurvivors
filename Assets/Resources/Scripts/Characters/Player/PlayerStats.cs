using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private PlayerData _playerData;

        private float _maxHealth;
        private float _recovery;
        private float _moveSpeed;
        private float _projectileSpeed;

        ///to clean
        public int _exp = 0;
        public int _level = 1;
        public int _expGoal = 10;
        public List<LevelRange> _levelRanges;

        private void Awake()
        {
            _maxHealth = _playerData.MaxHealth;
            _recovery = _playerData.Recovery;
            _moveSpeed = _playerData.MoveSpeed;
            _projectileSpeed = _playerData.ProjectileSpeed;
        }

        private void Start()
        {
            _expGoal = _levelRanges[0]._expGoalIncrease;
        }

        public void IncreaseExperience(int amount)
        {
            _exp += amount;

            CheckLevelUp();
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
