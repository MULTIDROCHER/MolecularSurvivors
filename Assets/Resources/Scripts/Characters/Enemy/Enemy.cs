using UnityEngine;

namespace MolecularSurvivors
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyData _enemyData;
        private Player _player;
        private DropLootManager _drop;

        public Player Player => _player;
        public EnemyData EnemyData => _enemyData;

        public Health Health { get; private set; }

        private void Awake()
        {
            Health = GetComponentInChildren<Health>();
        }

        public void Set(Player player, HealthChangesDisplay healthChanges, DropLootManager drop)
        {
            _player = player;
            Health.SetDisplay(healthChanges);
            _drop = drop;
        }

        private void OnDisable()
        {
            _drop?.InstantiateLoot(transform.position);
        }
    }
}