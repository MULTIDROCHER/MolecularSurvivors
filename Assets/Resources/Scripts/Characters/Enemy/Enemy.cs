using System;
using UnityEngine;

namespace MolecularSurvivors
{
    public class Enemy : Character<EnemyData>
    {
        public Player Player { get; private set; }

        public event Action<Enemy> Died;

        public void Initialize(Player player, HealthChangesDisplay changesDisplay)
        {
            Player = player;
            Health = new(transform, changesDisplay);
            Movement = new EnemyMovement(GetComponent<Rigidbody2D>(), Data.MoveSpeed, Player.transform);
        }

        public virtual void Set(EnemyData data)
        {
            Data = data;
            Renderer.sprite = Data.Sprite;
            Health.Set(data);
        }

        protected override void Die() => Died.Invoke(this);
    }
}