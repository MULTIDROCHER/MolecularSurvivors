using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class UpgradeComponent : ComponentData
    {
        [SerializeField] private List<UpgradeData> _upgrades = new();

        private EquipmentData _equipment;

        public int MaxLevel { get; private set; }
        public int CurrentLevel { get; private set; }
        public bool CanLevelUp => CurrentLevel < MaxLevel;

        public void Initialize(EquipmentData equipment)
        {
            _equipment = equipment;
            CurrentLevel = 0;
            MaxLevel = _upgrades.Count;
        }

        public UpgradeData ShowNext()
        {
            return _upgrades[CurrentLevel];
        }

        public void LevelUp(UpgradeData newLevel)
        {
            if (CanLevelUp)
            {
                CurrentLevel++;
                _equipment.GetComponent(newLevel.Type)?.ChangeValue(newLevel.Value, newLevel.IsPercent);
            }
        }
    }
}