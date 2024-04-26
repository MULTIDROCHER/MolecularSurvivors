using System;
using UnityEngine;
using Zenject;

namespace MolecularSurvivors
{
    public class Player : Character<PlayerData>
    {
        //create operator for setting choosen player data on scene start
        private PlayerAnimator _animator;

        public event Action Died;

        public Inventory Inventory { get; private set; }
        public LootCollector LootCollector { get; private set; }
        public PlayerStats Stats { get; private set; } = new();
        public PlayerMovement PlayerMovement => (PlayerMovement)Movement;

        [Inject]
        private void Construct(Inventory inventory, EventBus eventBus)
        {
            Inventory = inventory;

            Health = new CharacterHealth(transform, eventBus);
            Health.Set(Data);
            GetComponentInChildren<HealthBar>()?.Set(Health, eventBus);
        }

        protected override void Awake()
        {
            base.Awake();

            Movement = new PlayerMovement(GetComponent<Rigidbody2D>(), Data.MoveSpeed);
            _animator = new(Movement, GetComponentInChildren<Animator>());

            LootCollector = GetComponentInChildren<LootCollector>();

            Inventory.Add(Data.StartWeapon);
            Inventory.Add(Data.StartAbility);
        }

        protected override void Update()
        {
            base.Update();
            _animator.Update();
        }

        protected override void Die() => Died?.Invoke();
    }
}