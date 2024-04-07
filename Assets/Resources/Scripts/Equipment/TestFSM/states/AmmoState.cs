using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace MolecularSurvivors
{
    [Serializable]
    public abstract class AmmoState
    {
        [field: SerializeField] public bool ShootFromPlayer { get; private set; }

        [field: SerializeField] protected Sprite Sprite { get; private set; }
        [field: SerializeField] protected float Duration { get; private set; }

        protected Ammo Ammo;
        protected float _timer;

        public event Action Completed;

        public virtual void Enter()
        {
            _timer = Duration;

            if (Sprite != null)
                if (Ammo.Renderer != null)
                    Ammo.Renderer.sprite = Sprite;
                else
                    Debug.Log("null renderer");
        }

        public virtual void Update(float deltaTime)
        {
            _timer -= deltaTime;

            if (_timer <= 0)
                Completed?.Invoke();
        }

        public void GetAmmo(Ammo ammo) => Ammo = ammo;
    }
}