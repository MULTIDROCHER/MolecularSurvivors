using UnityEngine;

namespace MolecularSurvivors
{
    public abstract class Movement
    {
        protected readonly Rigidbody2D Rigidbody;

        protected float Speed;

        public Vector3 MovementDirection { get; protected set; }

        public Movement(Rigidbody2D rigidbody, float startSpeed)
        {
            Rigidbody = rigidbody;
            Speed = startSpeed;
        }

        public abstract void SetDirection();

        public virtual void Move()
        {
            Rigidbody.velocity = MovementDirection * Speed;
        }

        public virtual void ChangeSpeed(float newValue) => Speed = newValue;
    }
}