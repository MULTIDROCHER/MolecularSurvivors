using DG.Tweening;
using UnityEngine;

namespace MolecularSurvivors
{
    public class Ability : Equipment<AbilityData>
    {
        public override void Execute()
        {
            Controller.Player.Renderer.DOColor(Data.Color, Data.DurationData.Duration)
            .OnComplete(() => 
            Controller.Player.Renderer.DOColor(Color.white, Data.DurationData.Duration));
        }
    }
}