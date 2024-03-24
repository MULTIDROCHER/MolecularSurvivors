using UnityEngine;

namespace MolecularSurvivors
{
    public class Enemy : MonoBehaviour
    {
        [field: SerializeField] public EnemyData EnemyData { get; private set; }

        public Player Player { get; private set; }
        public CharactersHealth Health { get; private set; }

        private void Awake()
        {
            Health = GetComponentInChildren<CharactersHealth>();
        }

        public void Set(Player player, HealthChangesDisplay healthChanges)
        {
            Player = player;
            Health.SetDisplay(healthChanges);
        }
    }
}