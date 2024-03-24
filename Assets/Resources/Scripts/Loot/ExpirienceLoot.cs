using UnityEngine;

namespace MolecularSurvivors
{
    [CreateAssetMenu(fileName = "Loot", menuName = "Loot/Exp", order = 0)]
    public class ExpirienceLoot : Loot
    {
        [field: SerializeField] public int Exp { get; private set; }
    }
}