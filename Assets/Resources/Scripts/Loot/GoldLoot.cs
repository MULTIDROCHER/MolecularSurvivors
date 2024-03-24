using UnityEngine;

namespace MolecularSurvivors
{
    [CreateAssetMenu(fileName = "Loot", menuName = "Loot/Gold", order = 0)]
    public class GoldLoot : Loot
    {
        [field: SerializeField] public int Gold { get; private set; }
    }
}