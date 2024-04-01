using System;
using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    [Serializable]
    public class EnemyWave
    {
        [field: SerializeField] public List<EnemyData> Enemies { get; private set; }
        [field: SerializeField] public int EnemiesCountIncrease { get; private set; }
    }
}