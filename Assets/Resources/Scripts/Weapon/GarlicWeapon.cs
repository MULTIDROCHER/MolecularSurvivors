using UnityEngine;

namespace MolecularSurvivors
{
    public class GarlicWeapon : AreaWeapon
    {
        [SerializeField] private GarlicAmmo _prefab;
        [SerializeField] private float _duration;

        private GarlicAmmo _spawned;

        public float Duration => _duration;

        protected override void Start()
        {
            base.Start();
            _spawned = Instantiate(_prefab.gameObject, transform).GetComponent<GarlicAmmo>();
        }

        protected override void Attack()
        {
            base.Attack();
            _spawned.Activate();
        }
    }
}
