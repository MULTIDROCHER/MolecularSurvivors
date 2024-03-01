using UnityEngine;

namespace MolecularSurvivors.Environment
{
    public class MapChunk : MonoBehaviour
    {
        public MapController Controller { get; private set; }

        public ChunkSpawnPoints SpawnPoints { get; private set; }

        private void Awake()
        {
            Controller = GetComponentInParent<MapController>();
            SpawnPoints = GetComponent<ChunkSpawnPoints>();
        }
    }
}