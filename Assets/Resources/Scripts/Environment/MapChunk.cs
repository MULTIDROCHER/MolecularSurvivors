using UnityEngine;

namespace MolecularSurvivors.Environment
{
    public class MapChunk : MonoBehaviour
    {
        public MapController Controller { get; private set; }

        public ChunkSpawnPoints ChunkSpawnPoints { get; private set; }

        public BreakablesSpawner BreakablesSpawner { get; private set; }

        private void Awake()
        {
            Controller = GetComponentInParent<MapController>();
            ChunkSpawnPoints = GetComponent<ChunkSpawnPoints>();
            BreakablesSpawner = GetComponentInChildren<BreakablesSpawner>();
        }
    }
}