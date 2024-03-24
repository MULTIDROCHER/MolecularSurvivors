using UnityEngine;

namespace MolecularSurvivors
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private HealthChangesDisplay _healthChangesDisplay;

        public PlayerData PlayerData => _playerData;

        public CharactersHealth Health { get; private set; }

        public PlayerMovement Movement { get; private set; }

        public SpriteRenderer Renderer { get; private set; }

        public GoldCollector GoldCollector {get; private set;}

        private void Awake()
        {
            Health = GetComponentInChildren<CharactersHealth>();
            Movement = GetComponent<PlayerMovement>();
            Health.SetDisplay(_healthChangesDisplay);
            Renderer = GetComponentInChildren<SpriteRenderer>();
            GoldCollector = GetComponentInChildren<GoldCollector>();
        }
    }
}