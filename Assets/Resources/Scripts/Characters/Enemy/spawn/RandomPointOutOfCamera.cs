using UnityEngine;

namespace MolecularSurvivors
{
    public class RandomPointOutOfCamera
    {
        private Vector3 _spawnArea = new (14, 8);
        private Vector3 _randomPosition;
        private float _multiplier;
        private Camera _camera;

        public RandomPointOutOfCamera(Camera camera) => _camera = camera;

        public Vector3 GetRandomPoint()
        {
            _multiplier = Random.value > .5f ? -1f : 1f;

            if (Random.value > .5f)
                _randomPosition = new (Random.Range(-_spawnArea.x, _spawnArea.x), _spawnArea.y * _multiplier);
            else
                _randomPosition = new (_spawnArea.x * _multiplier, Random.Range(-_spawnArea.y, _spawnArea.y));

            _randomPosition += _camera.transform.position;
            _randomPosition.z = 0;

            return _randomPosition;
        }
    }
}