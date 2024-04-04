using UnityEngine;

namespace MolecularSurvivors
{
    public class Enemy : Character<EnemyData>
    {
        public Player Player { get; private set; }

        public void Initialize(Player player, HealthChangesDisplay healthChanges)
        {
            Player = player;
            Health = new(transform, healthChanges);
            Movement = new EnemyMovement(GetComponent<Rigidbody2D>(), Data.MoveSpeed, Player.transform);
        }

        public virtual void Set(EnemyData data)
        {
            Data = data;
            Renderer.sprite = Data.Sprite;
            Health.Set(data);
        }
    }
}