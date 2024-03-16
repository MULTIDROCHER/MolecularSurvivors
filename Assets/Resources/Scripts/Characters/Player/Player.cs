using UnityEngine;

namespace MolecularSurvivors
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private HealthChangesDisplay _healthChangesDisplay;

        public PlayerData PlayerData => _playerData;

        public Health Health { get; private set; }

        public PlayerMovement Movement { get; private set; }

        private void Awake()
        {
            Health = GetComponentInChildren<Health>();
            Movement = GetComponent<PlayerMovement>();
            Health.SetDisplay(_healthChangesDisplay);
        }
    }
}