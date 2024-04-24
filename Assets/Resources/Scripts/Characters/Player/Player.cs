using System;
using UnityEngine;
using Zenject;

namespace MolecularSurvivors
{
    public class Player : Character<PlayerData>
    {
        //create operator for setting choosen player data on scene start
        [SerializeField] private HealthBar _healthbar;

        private PlayerAnimator _animator;
        [Inject] private HealthChangesDisplay _changesDisplay;


        public event Action Died;

        [Inject] public Inventory Inventory { get; private set; }
        public LootCollector LootCollector { get; private set; }
        public PlayerStats Stats { get; private set; } = new();
        public PlayerMovement PlayerMovement => (PlayerMovement)Movement;

        protected override void Awake()
        {
            base.Awake();

            Movement = new PlayerMovement(GetComponent<Rigidbody2D>(), Data.MoveSpeed);
            _animator = new(Movement, GetComponentInChildren<Animator>());

            LootCollector = GetComponentInChildren<LootCollector>();

            Health = new CharacterHealth(transform, _changesDisplay);
            Health.Set(Data);
            _healthbar.Set(Health);

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