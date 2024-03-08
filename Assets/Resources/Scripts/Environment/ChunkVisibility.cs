using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors.Environment
{
    public class ChunkVisibility
    {
        private readonly Player _player;
        private readonly float _visibleDistance = 50;

        private float _currentDistance;

        public ChunkVisibility(Player player) => _player = player;

        public List<MapChunk> Spawned { get; private set; } = new();

        public void Add(MapChunk chunk) => Spawned.Add(chunk);

        public void ShowOnlyCloseChunks()
        {
            foreach (var chunk in Spawned)
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