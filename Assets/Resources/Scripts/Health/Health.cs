using UnityEngine;

namespace MolecularSurvivors
{
    [RequireComponent(typeof(HealthOperations))]
    public class Health : MonoBehaviour
    {
        [SerializeField] private CharacterData _character;

        public int Current { get; protected set; }

        public int MaxAmount { get; protected set; }

        public HealthOperations Operations { get; private set; }

        private void Awake()
        {
            Operations = GetComponent<HealthOperations>();
            Current = _character.MaxHealth;
        }
    }
}