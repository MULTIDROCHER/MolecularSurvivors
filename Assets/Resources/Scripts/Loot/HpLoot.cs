using UnityEngine;

namespace MolecularSurvivors
{
    [CreateAssetMenu(fileName = "Loot", menuName = "Loot/Health", order = 0)]
    public class HpLoot : Loot
    {
        [field: SerializeField] public int HealthRecovery { get; private set; }
    }
}