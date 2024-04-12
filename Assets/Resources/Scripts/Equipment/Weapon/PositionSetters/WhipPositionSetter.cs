using UnityEngine;

namespace MolecularSurvivors
{
    public class WhipPositionSetter : AmmoPositionSetter
    {
        private readonly float _offsetX = 1.5f;
        private readonly float _startOffsetY = -.2f;
        private readonly float _offsetYIncrement = .35f;

        public override void SetPositions(Ammo[] ammos)
        {
            bool right = Weapon.EquipmentController.Player.PlayerMovement.LastMovementVector.x > 0;
            float y = _startOffsetY;

            RotateByDirection(ammos[0], y, right);

            for (int i = 0; i < ammos.Length; i++)
            {
                RotateByDirection(ammos[i], y += _offsetYIncrement, i % 2 == (right ? 0 : 1));
            }
        }

        private void RotateByDirection(Ammo ammo, float positionY, bool right)
        {
            ammo.transform.localPosition = Vector3.right * (right ? _offsetX : -_offsetX) + Vector3.up * positionY;
            ammo.transform.eulerAngles = Vector3.forward * (right ? -90f : 90f);
        }
    }
}