using UnityEngine;

namespace MolecularSurvivors
{
    [RequireComponent(typeof(HealthOperations))]
    public class Health : MonoBehaviour
    {
        public int Current { get; protected set; }

        public HealthOperations Operations { get; private set; }

        private void Awake()
        {
            Operations = GetComponent<HealthOperations>();
            Current = Operations.MaxAmount;
        }
    }
}