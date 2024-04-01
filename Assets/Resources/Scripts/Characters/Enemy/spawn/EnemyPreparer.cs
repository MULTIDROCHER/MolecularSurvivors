using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class EnemyPreparer
    {
        private List<EnemyData> _enemies = new();
        private RandomPointOutOfCamera _randomPointGenerator;

        public EnemyPreparer(Camera camera) => _randomPointGenerator = new(camera);

        public void UpdateDataList(EnemyWave wave)
        {
            if (wave.Enemies != null)
                _enemies = wave.Enemies;
        }

        public Enemy Set(Enemy enemy)
        {
            var data = GetRandomData();
            enemy.Set(data);
            enemy.transform.position = _randomPointGenerator.GetRandomPoint();
            enemy.gameObject.SetActive(true);

            return enemy;
        }

        private EnemyData GetRandomData() => _enemies[Random.Range(0, _enemies.Count)];
    }
}