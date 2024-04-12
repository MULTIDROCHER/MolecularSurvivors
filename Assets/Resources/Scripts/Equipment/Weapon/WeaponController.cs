using UnityEngine;

namespace MolecularSurvivors
{
    public class WeaponController : EquipmentController<WeaponData>
    {
        [field: SerializeField] public Transform[] ShootPoints { get; private set; }
        [SerializeField] private EnemySpawner _enemySpawner;

        public Enemy GetNearestEnemy() => _enemySpawner.GetNearestEnemy();

        public Enemy GetRandomEnemy() => _enemySpawner.GetRandomEnemy();
    }
}