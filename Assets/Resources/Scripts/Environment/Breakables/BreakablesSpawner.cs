using UnityEngine;

namespace MolecularSurvivors.Environment
{
    public class BreakablesSpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPoints;
        private BreakablesController _controller;

        public void GetController(BreakablesController controller) => _controller = controller;

        public void Spawn()
        {
            var amount = Random.Range(0, _controller.MaxAmountOnChunk);

            if (amount > _spawnPoints.Length)
                amount = _spawnPoints.Length;

            for (int i = 0; i < amount; i++)
            {
                var itemIndex = Random.Range(0, _controller.Templates.Count);

                Instantiate(_controller.Templates[itemIndex], _spawnPoints[i].position, Quaternion.identity, transform);
            }
        }

        public void OnBreaked(Transform transform)
        {
            _controller.SetLoot(transform);
            transform.gameObject.SetActive(false);
        }
    }
}