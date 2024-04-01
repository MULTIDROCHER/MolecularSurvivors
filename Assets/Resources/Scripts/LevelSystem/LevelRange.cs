using System;
using UnityEngine;

namespace MolecularSurvivors
{
    [Serializable]
    public class LevelRange
    {
        [field: SerializeField] public int StartLevel { get; private set; }
        [field: SerializeField] public int EndLevel { get; private set; }
        [field: SerializeField] public int GoalIncrease { get; private set; }
        [field: SerializeField] public EnemyWave EnemyWave { get; private set; }
    }
}