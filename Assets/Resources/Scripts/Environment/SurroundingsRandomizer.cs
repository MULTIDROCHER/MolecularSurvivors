using UnityEngine;

namespace MolecularSurvivors.Environment
{
    public class SurroundingsRandomizer : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private Transform[] _prefabs;

        private void Start() => SetRandomSurroundings();

        private void SetRandomSurroundings()
        {
            foreach (var point in _spawnPoints)
            {
                var itemIndex = Random.Range(0, _prefabs.Length);
                Instantiate(_prefabs[itemIndex], point);
            }
        }
    }
}