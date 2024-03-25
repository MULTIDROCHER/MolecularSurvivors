using UnityEngine;

namespace MolecularSurvivors
{
    [CreateAssetMenu(fileName = "DefaultReward", menuName = "Reward/DefaultReward", order = 0)]
    public class DefaultReward : ScriptableObject, IReward
    {
        [field: SerializeReference] public TextComponent TextData { get; private set; } = new();
        [field: SerializeField] public Loot Loot { get; private set; }
    }
}