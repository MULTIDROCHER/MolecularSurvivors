using System.Linq;
using UnityEngine;

namespace MolecularSurvivors.Environment
{
    public class MapController : MonoBehaviour
    {
        [SerializeField] private MapChunk[] _templates;
        [SerializeField] private Player _player;
        [SerializeField] private LayerMask _layer;
        [SerializeField] private float _spawnDelay;

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
                    SetChunkAtPoint(_current.SpawnPoints.Right.position);
                    break;
                case { x: < 0, y: 0 }:
                    SetChunkAtPoint(_current.SpawnPoints.Left.position);
                    break;
                case { x: 0, y: > 0 }:
                    SetChunkAtPoint(_current.SpawnPoints.Up.position);
                    break;
                case { x: 0, y: < 0 }:
                    SetChunkAtPoint(_current.SpawnPoints.Down.position);
                    break;
                case { x: > 0, y: > 0 }:
                    SetChunkAtPoint(_current.SpawnPoints.RightUp.position);
                    break;
                case { x: < 0, y: > 0 }:
                    SetChunkAtPoint(_current.SpawnPoints.LeftUp.position);
                    break;
                case { x: > 0, y: < 0 }:
                    SetChunkAtPoint(_current.SpawnPoints.RightDown.position);
                    break;
                case { x: < 0, y: < 0 }:
                    SetChunkAtPoint(_current.SpawnPoints.LeftDown.position);
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