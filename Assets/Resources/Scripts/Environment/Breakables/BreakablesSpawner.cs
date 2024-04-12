using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors.Environment
{
    public class BreakablesSpawner : MonoBehaviour
    {
        private readonly List<BreakableObject> _spawned = new();

        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private ParticleSystem _effect;
        
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

                var obj = Instantiate(_controller.Templates[itemIndex], _spawnPoints[i].position, Quaternion.identity, transform);
                obj.Breaked += OnBreaked;
                _spawned.Add(obj);
            }
        }

        private void OnEnable()
        {
            if (_spawned.Count > 0)
                foreach (var obj in _spawned)
                    if (obj.gameObject.activeSelf == false)
                        obj.Rebuild();
        }

        public void OnBreaked(BreakableObject breakable)
        {
            _controller.SetLoot(breakable.transform);
            _effect.transform.position = breakable.transform.position;
            _effect.Play();
            breakable.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            foreach (var obj in _spawned)
                obj.Breaked -= OnBreaked;
        }
    }
}