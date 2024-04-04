using UnityEngine;

namespace MolecularSurvivors.Environment
{
    public class MapController : MonoBehaviour
    {
        [SerializeField] private MapChunk[] _templates;
        [SerializeField] private Player _player;
        [SerializeField] private BreakablesController _breakablesController;

        private ChunkVisibility _chunkVisibility;
        private ChunkSpawner _spawner;
        private MapUpdater _mapUpdater;
        private Movement _movement;
        private MapChunk _current;

        public MapChunk CurrentChunk => _current;

        private void Start()
        {
            _movement = _player.Movement;
            _chunkVisibility = new(_player);
            _spawner = new(_templates, transform);
            _mapUpdater = new();
        }

        private void Update()
        {
            _mapUpdater.Update();
            UpdateMap();
        }

        public void SetCurrentChunk(MapChunk chunk) => _current = chunk;

        private void UpdateMap()
        {
            if (_current == null)
                return;

            SetChunkAtPoint(GetSpawnPoint());
        }

        private void SetChunkAtPoint(Vector3 position)
        {
            if (ChunkIsAbcent(position) && _mapUpdater.TryToSpawnChunk())
            {
                _spawner.Spawn(position, out MapChunk chunk);
                _breakablesController.Spawn(chunk);
                _chunkVisibility.Add(chunk);
            }
        }

        private bool ChunkIsAbcent(Vector3 position)
        {
            _chunkVisibility.ShowOnlyCloseChunks();
            return transform.Find(position.ToString()) == null;
        }

        private Vector3 GetSpawnPoint()
        {
            return _movement.MovementDirection switch
            {
                { x: > 0, y: 0 } => _current.ChunkSpawnPoints.Right.position,
                { x: < 0, y: 0 } => _current.ChunkSpawnPoints.Left.position,
                { x: 0, y: > 0 } => _current.ChunkSpawnPoints.Up.position,
                { x: 0, y: < 0 } => _current.ChunkSpawnPoints.Down.position,
                { x: > 0, y: > 0 } => _current.ChunkSpawnPoints.RightUp.position,
                { x: < 0, y: > 0 } => _current.ChunkSpawnPoints.LeftUp.position,
                { x: > 0, y: < 0 } => _current.ChunkSpawnPoints.RightDown.position,
                { x: < 0, y: < 0 } => _current.ChunkSpawnPoints.LeftDown.position,
                _ => Vector3.zero,
            };
        }
    }
}