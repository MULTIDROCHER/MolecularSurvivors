using MolecularSurvivors.Environment;
using UnityEngine;

namespace MolecularSurvivors
{
    public class BreakableObject : MonoBehaviour
    {
        public ObjectHealth Health { get; private set; }
        private BreakablesSpawner _spawner;

        private void Awake()
        {
            Health = GetComponentInChildren<ObjectHealth>();
            _spawner = GetComponentInParent<BreakablesSpawner>();

            Health.Initialize();
            Health.Died += OnBreaked;
        }

        private void OnDisable() => Health.Died -= OnBreaked;

        private void OnBreaked() => _spawner.OnBreaked(transform);
    }
}