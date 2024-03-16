using UnityEngine;

namespace MolecularSurvivors
{
    [CreateAssetMenu(fileName = "Loot", menuName = "Loot", order = 0)]
    public class Loot : ScriptableObject
    {
        [field: SerializeField] public Sprite Sprite { get; private set; }
        [field: SerializeField] public int DropChance { get; private set; }
        [field: SerializeField] public int Exp { get; private set; }
    }
}