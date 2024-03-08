using UnityEngine;

namespace MolecularSurvivors.Environment
{
    public class ChunkSpawner
    {
        private readonly MapChunk[] _templates;
        private readonly Transform _parentTransform;

        public ChunkSpawner(MapChunk[] templates, Transform parentTransform)
        {
            _templates = templates;
            _parentTransform = parentTransform;
        }

        public void Spawn(Vector3 position, out MapChunk chunk)
        {
            chunk = Object.Instantiate(GetRandomChunk(), position, Quaternion.identity, _parentTransform);
            chunk.name = position.ToString();
        }

        private MapChunk GetRandomChunk() => _templates[Random.Range(0, _templates.Length)];
    }
}