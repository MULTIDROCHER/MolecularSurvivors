using Zenject;

namespace MolecularSurvivors
{
    public class WeaponController : EquipmentController<WeaponData>
    {
        [Inject]private EnemySpawner _enemySpawner;

        public AmmoPositionSetter GetPositionSetter(Weapon weapon)
        {
            return weapon.Data.PositionSetterType switch
            {
                AmmoPositionType.Whip => new WhipPositionSetter(weapon),
                _ => new DefaultPositionSetter(weapon),
            };
        }

        public Enemy GetNearestEnemy() => _enemySpawner.GetNearestEnemy();

        public Enemy GetRandomEnemy() => _enemySpawner.GetRandomEnemy();
    }
}