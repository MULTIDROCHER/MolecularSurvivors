using UnityEngine;

namespace MolecularSurvivors
{
    public class Player : MonoBehaviour
    {
        public Health Health { get; private set; }

        public PlayerMovement Movement { get; private set; }

        private void Awake()
        {
            Health = GetComponentInChildren<Health>();
            Movement = GetComponent<PlayerMovement>();
        }
    }
}