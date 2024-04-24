using UnityEngine;
using Zenject;

namespace MolecularSurvivors.Environment
{
    public class MapController : MonoBehaviour
    {
        [Inject] private readonly Player _player;

        [SerializeField] private MapChunk[] _templates;
        [SerializeField] private BreakablesController _breakablesController;

        private ChunkVisibility _chunkVisibility;
        private MapUpdater _mapUpdater;
        private ChunkSpawner _spawner;
        private Movement _movement;
        private MapChunk _current;

        public MapChunk CurrentChunk => _current;

        private void Start()
        {
            _movement = _player.PlayerMovement;
            _spawner = new(_templates, transform);
            _chunkVisibility = new(_player);
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
            //todo clean this
            _chunkVisibility.ShowOnlyCloseChunks();
            return transform.Find(position.ToString()) == null;
        }

        private Vector3 GetSpawnPoint()
        {
            //and this(or move)
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