using UnityEngine;

namespace MolecularSurvivors
{
    public class Player : MonoBehaviour
    {
        [field: SerializeField] public PlayerData Data { get; protected set; }
        [SerializeField] private HealthChangesDisplay _healthChangesDisplay;
        [SerializeField] private LevelProgress _levelProgress;
        [SerializeField] private GoldCollector _goldCollector;

        public PlayerHealth Health { get; private set; }
        public PlayerMovement Movement { get; private set; }
        public SpriteRenderer Renderer { get; private set; }
        public ResourceHandler ResourceHandler { get; private set; }

        private void Awake()
        {
            Movement = GetComponent<PlayerMovement>();

            Health = GetComponentInChildren<PlayerHealth>();
            Renderer = GetComponentInChildren<SpriteRenderer>();

            ResourceHandler = new(_levelProgress, Health, _goldCollector);
            Health.Initialize(_healthChangesDisplay);
            Health.Set(Data);
        }
    }
}