using System;
using UnityEngine;

namespace MolecularSurvivors
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Character<T> : MonoBehaviour, IDamagable where T : CharacterData
    {
        [field: SerializeField] public T Data { get; protected set; }

        public SpriteRenderer Renderer { get; private set; }

        public Movement Movement { get; protected set; }
        protected CharacterHealth Health;

        public virtual event Action<Character<T>> Died;

        protected virtual void Awake()
        {
            Renderer = GetComponentInChildren<SpriteRenderer>();
        }

        #region IDamagable
        public void Recover(int amount)
        {
            Health.Recover(amount);
        }

        public void ApplyDamage(int amount)
        {
            if (Health.Current <= 0)
                return;

            Health.ApplyDamage(amount);

            if (Health.Current <= 0)
                Die();
        }

        private void Die()
        {
            Died?.Invoke(this);
        }
        #endregion

        #region Update
        protected virtual void Update()
        {
            Movement.SetDirection();
        }

        protected virtual void FixedUpdate()
        {
            Movement.Move();
        }
        #endregion
    }
}