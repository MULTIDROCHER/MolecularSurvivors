using System.Collections;
using UnityEngine;

namespace MolecularSurvivors
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private EnemyData _enemyData;

        public Player Player => _player;
        public EnemyData EnemyData => _enemyData;

        public Health Health { get; private set; }

        private void Awake()
        {
            Health = GetComponentInChildren<Health>();
        }
    }
}