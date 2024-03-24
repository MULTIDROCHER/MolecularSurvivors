using UnityEngine;

namespace MolecularSurvivors
{
    public abstract class Loot : ScriptableObject
    {
        [field: SerializeField] public Sprite Sprite { get; private set; }
        [field: SerializeField] public int DropChance { get; private set; }
    }
}