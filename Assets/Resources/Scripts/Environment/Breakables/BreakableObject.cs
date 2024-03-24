using MolecularSurvivors.Environment;
using UnityEngine;

namespace MolecularSurvivors
{
    public class BreakableObject : MonoBehaviour
    {
        private ObjectHealth _health;
        private BreakablesSpawner _spawner;

        private void Awake()
        {
            _health = GetComponent<ObjectHealth>();
            _spawner = GetComponentInParent<BreakablesSpawner>();

            _health.Died += OnBreaked;
        }

        private void OnDisable() => _health.Died -= OnBreaked;

        private void OnBreaked() => _spawner.OnBreaked(transform);
    }
}