using DG.Tweening;
using UnityEngine;

namespace MolecularSurvivors
{
    public class Ability : Equipment<AbilityData>
    {
        public override void Execute()
        {
            Player.Renderer.DOColor(Data.Color, Data.DurationData.Duration)
            .OnComplete(() => Player.Renderer.DOColor(Color.white, Data.DurationData.Duration));
        }
    }
}