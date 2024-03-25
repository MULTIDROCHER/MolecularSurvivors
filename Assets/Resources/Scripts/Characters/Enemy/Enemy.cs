using UnityEngine;

namespace MolecularSurvivors
{
    public class Enemy : Character<EnemyData>
    {
        public Player Player { get; private set; }

        public void Set(Player player, HealthChangesDisplay healthChanges)
        {
            Player = player;
            Health.SetDisplay(healthChanges);
        }
    }
}