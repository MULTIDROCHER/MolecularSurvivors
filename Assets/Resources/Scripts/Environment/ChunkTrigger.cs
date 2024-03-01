using UnityEngine;

namespace MolecularSurvivors.Environment
{
    public class ChunkTrigger : MonoBehaviour
    {
        [SerializeField] private MapChunk _chunk;

        private MapController _mapController;

        private void Start() => _mapController = _chunk.Controller;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Player _))
                _mapController.SetCurrentChunk(_chunk);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out Player _))
                if (_mapController.CurrentChunk == _chunk)
                    _mapController.SetCurrentChunk(null);
        }
    }
}