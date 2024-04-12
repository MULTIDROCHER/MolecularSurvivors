using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class EnemyPreparer
    {
        private readonly EnemySpawnArea _spawnArea;
        private readonly WaitForSeconds _duration = new(.5f);
        
        private List<EnemyData> _enemies = new();

        public EnemyPreparer(Camera camera) => _spawnArea = new(camera);

        public void UpdateDataList(EnemyWave wave)
        {
            if (wave.Enemies != null)
                _enemies = wave.Enemies;
        }

        public IEnumerator Set(Enemy enemy)
        {
            enemy.gameObject.SetActive(false);

            yield return _duration;

            var data = GetRandomData();
            enemy.Set(data);
            enemy.transform.position = _spawnArea.GetRandomPoint();
            enemy.gameObject.SetActive(true);
        }

        private EnemyData GetRandomData() => _enemies[Random.Range(0, _enemies.Count)];
    }
}