using DG.Tweening;
using UnityEngine;

namespace MolecularSurvivors
{
    public class Ability : Equipment<AbilityData>
    {
        private DurationComponent _durationData;

        public override void Initialize(AbilityData data, EquipmentController<AbilityData> controller)
        {
            base.Initialize(data, controller);
            _durationData = (DurationComponent)Data.GetComponent(ComponentType.Duration);
        }

        public override void Execute()
        {
            EquipmentController.Player.Renderer.DOColor(Color.black, _durationData.Duration)
            .OnComplete(() =>
            EquipmentController.Player.Renderer.DOColor(Color.white, _durationData.Duration));
        }
    }
}