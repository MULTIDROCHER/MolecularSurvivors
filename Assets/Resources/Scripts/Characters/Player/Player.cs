using UnityEngine;

namespace MolecularSurvivors
{
    public class Player : Character<PlayerData>
    {
        [SerializeField] private HealthChangesDisplay _healthChangesDisplay;
        [SerializeField] private LevelProgress _levelProgress;
        [SerializeField] private GoldCollector _goldCollector;

        public PlayerMovement Movement { get; private set; }
        public SpriteRenderer Renderer { get; private set; }
        public ResourceHandler ResourceHandler { get; private set; }

        protected override void Awake()
        {
            base.Awake();

            Movement = GetComponent<PlayerMovement>();
            Health.SetDisplay(_healthChangesDisplay);
            Renderer = GetComponentInChildren<SpriteRenderer>();

            ResourceHandler = new(_levelProgress, Health, _goldCollector);
        }
    }
}