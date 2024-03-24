using UnityEngine;

namespace MolecularSurvivors.Environment
{
    public class MapController : MonoBehaviour
    {
        [SerializeField] private MapChunk[] _templates;
        [SerializeField] private Player _player;
        [SerializeField] private LayerMask _layer;
        [SerializeField] private float _spawnDelay;
        [SerializeField] private BreakablesController _breakablesController;

        private ChunkVisibility _chunkVisibility;
        private ChunkSpawner _spawner;
        private PlayerMovement _movement;
        private MapChunk _current;
        private float _delay;

        public MapChunk CurrentChunk => _current;

        private void Start()
        {
            _movement = _player.Movement;
            _chunkVisibility = new(_player);
            _spawner = new(_templates, transform);
        }

        private void Update()
        {
            _delay -= Time.deltaTime;
            UpdateMap();
        }

        public void SetCurrentChunk(MapChunk chunk) => _current = chunk;

        private void UpdateMap()
        {
            if (_current == null)
                return;

            switch (_movement.Movement)
            {
                case { x: > 0, y: 0 }:
                    SetChunkAtPoint(_current.ChunkSpawnPoints.Right.position);
                    break;
                case { x: < 0, y: 0 }:
                    SetChunkAtPoint(_current.ChunkSpawnPoints.Left.position);
                    break;
                case { x: 0, y: > 0 }:
                    SetChunkAtPoint(_current.ChunkSpawnPoints.Up.position);
                    break;
                case { x: 0, y: < 0 }:
                    SetChunkAtPoint(_current.ChunkSpawnPoints.Down.position);
                    break;
                case { x: > 0, y: > 0 }:
                    SetChunkAtPoint(_current.ChunkSpawnPoints.RightUp.position);
                    break;
                case { x: < 0, y: > 0 }:
                    SetChunkAtPoint(_current.ChunkSpawnPoints.LeftUp.position);
                    break;
                case { x: > 0, y: < 0 }:
                    SetChunkAtPoint(_current.ChunkSpawnPoints.RightDown.position);
                    break;
                case { x: < 0, y: < 0 }:
                    SetChunkAtPoint(_current.ChunkSpawnPoints.LeftDown.position);
                    break;
                default:
                    return;
            }
        }

        private void SetChunkAtPoint(Vector3 position)
        {
            if (ChunkIsAbcent(position) && TryToSpawnChunk())
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

        private bool TryToSpawnChunk()
        {
            if (_delay <= 0)
            {
                _delay = _spawnDelay;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}