using UnityEngine;

namespace MolecularSurvivors
{
    public class UpgradeComponent : ComponentData
    {
        [field: SerializeField] public int MaxLevel { get; private set; }
        public int Level { get; private set; } = 1;

        public bool CanLevelUp => Level < MaxLevel;

        public void LevelUp()
        {
            if (CanLevelUp)
                Level++;
        }
    }
}