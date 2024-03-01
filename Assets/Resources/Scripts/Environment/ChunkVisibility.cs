using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors.Environment
{
    public class ChunkVisibility
    {
        private readonly List<MapChunk> _spawned = new();
        private readonly Player _player;
        private readonly float _visibleDistance = 50;

        private float _currentDistance;

        public ChunkVisibility(Player player) => _player = player;

        public void AddSpawnedChunk(MapChunk chunk) => _spawned.Add(chunk);

        public void ShowOnlyCloseChunks()
        {
            foreach (var chunk in _spawned)
            {
                _currentDistance = Vector3.Distance(_player.transform.position, chunk.transform.position);

                if (_currentDistance > _visibleDistance)
                    chunk.gameObject.SetActive(false);
                else
                    chunk.gameObject.SetActive(true);
            }
        }
    }
}