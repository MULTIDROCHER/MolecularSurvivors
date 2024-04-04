using UnityEngine;

namespace MolecularSurvivors
{
    public class Player : Character<PlayerData>
    {
        //create operator for setting choosen player data on scene start
        [SerializeField] private HealthChangesDisplay _healthChangesDisplay;
        [SerializeField] private HealthBar _healthbar;
        [SerializeField] private LevelProgress _levelProgress;
        [SerializeField] private GoldCollector _goldCollector;

        private PlayerAnimator _animator;

        [field: SerializeField] public Inventory Inventory { get; private set; }
        public ResourceHandler ResourceHandler { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            Movement = new PlayerMovement(GetComponent<Rigidbody2D>(), Data.MoveSpeed);
            _animator = new(Movement, GetComponentInChildren<Animator>());
            Health = new CharacterHealth(transform, _healthChangesDisplay);
            Health.Set(Data);
            _healthbar.Set(Health);

            ResourceHandler = new(_levelProgress, this, _goldCollector);
        }

        protected override void Update()
        {
            base.Update();
            _animator.Update();
        }
    }
}