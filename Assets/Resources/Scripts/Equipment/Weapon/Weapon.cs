using System;
using System.Collections;
using UnityEngine;

namespace MolecularSurvivors
{
    public class Weapon : Equipment<WeaponData>
    {
        private readonly WaitForSeconds _shootDelay = new(.2f);
        private AmmoPool _pool;
        private AmmoPositionSetter _positionSetter;

        public WeaponController Controller => EquipmentController as WeaponController;

        public override void Initialize(WeaponData data, EquipmentController<WeaponData> controller)
        {
            base.Initialize(data, controller);
            _pool = new(this, Data.Ammo);
            _pool.CreateAmmos();
            SetScale();
            _positionSetter = Instantiate(Data.PositionSetter, transform);
        }

        public override void Execute()
        {
            var ammos = _pool.GetAmmos(Data.AmountData.Amount);
            _positionSetter.SetPositions(ammos);
            StartCoroutine(Execute(ammos));
        }

        public int SetDamage() => Data.DamageData.Damage + EquipmentController.Player.Stats.Damage;

        public float SetSpeed() => Data.SpeedData.Speed + Controller.Player.Stats.AmmoSpeed + Controller.Player.Data.MoveSpeed;

        public void SetScale()
        {
            foreach (var ammo in _pool.Ammos)
                ammo.transform.localScale = Data.Ammo.transform.localScale * EquipmentController.Player.Stats.AmmoScale;
        }

        private IEnumerator Execute(Ammo[] ammos)
        {
            var count = .2f;
            foreach (var ammo in ammos)
            {
                if (ammo != null)
                {
                    ammo.Activate();
                    StartCoroutine(Data.DurationData.Deactivate(ammo));
                    ammo.transform.localPosition += new Vector3(0, count, 0);
                    count += .2f;
                    yield return _shootDelay;
                }
            }
        }
    }
}