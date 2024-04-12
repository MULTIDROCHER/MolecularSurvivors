using UnityEngine;

namespace MolecularSurvivors
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Character<T> : MonoBehaviour, IDamagable where T : CharacterData
    {
        [field: SerializeField] public T Data { get; protected set; }

        protected CharacterHealth Health;
        protected Movement Movement;

        public SpriteRenderer Renderer { get; private set; }
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

        protected abstract void Die();
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