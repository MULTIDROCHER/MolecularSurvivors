using UnityEngine;

namespace MolecularSurvivors.Environment
{
    public class MapUpdater
    {
        private readonly float _delay = 1.5f;
        private float _timer;

        public void Update() => _timer -= Time.deltaTime;

        public bool TryToSpawnChunk()
        {
            if (_timer > 0)
                return false;

            _timer = _delay;
            return true;
        }
    }
}