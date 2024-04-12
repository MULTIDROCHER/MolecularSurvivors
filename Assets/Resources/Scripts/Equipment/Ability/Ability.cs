using DG.Tweening;
using UnityEngine;

namespace MolecularSurvivors
{
    public class Ability : Equipment<AbilityData>
    {
        public override void Execute()
        {
            EquipmentController.Player.Renderer.DOColor(Color.black, Data.DurationData.Duration)
            .OnComplete(() => 
            EquipmentController.Player.Renderer.DOColor(Color.white, Data.DurationData.Duration));
        }
    }
}