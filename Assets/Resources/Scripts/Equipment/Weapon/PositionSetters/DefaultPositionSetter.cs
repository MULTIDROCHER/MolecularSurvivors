using UnityEngine;

namespace MolecularSurvivors
{
    public class DefaultPositionSetter : AmmoPositionSetter
    {
        public override void SetPositions(Ammo[] ammos)
        {
            foreach (var ammo in ammos)
                ammo.transform.localPosition = Vector3.zero;
        }
    }
}