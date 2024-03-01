using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MolecularSurvivors.Environment
{
    public class ChunkSpawner
    {
        private readonly MapChunk[] _templates;
        private readonly float _spawnDelay = 3;
        private float _delay;
        private Transform _parentTransform;

        public ChunkSpawner(MapChunk[] templates, Transform parentTransform)
        {
            _templates = templates;
            _parentTransform = parentTransform;
        }

        public void SpawnChunk(Vector3 position, out MapChunk chunk)
        {
            chunk = Object.Instantiate(GetRandomChunk(), position, Quaternion.identity, _parentTransform);
        }

        private MapChunk GetRandomChunk() => _templates[Random.Range(0, _templates.Length)];
    }
}