using UnityEngine;

namespace MolecularSurvivors
{
    public class WeaponController : EquipmentController<WeaponData>
    {
        [field: SerializeField] public Transform[] ShootPoints { get; private set; }

        public Vector3 GetRandomShootPoint() => ShootPoints[Random.Range(0, ShootPoints.Length)].position;
    }
}