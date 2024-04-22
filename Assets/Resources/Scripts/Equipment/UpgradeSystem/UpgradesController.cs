using System.Collections.Generic;

namespace MolecularSurvivors
{
    public class UpgradesController<T> where T : EquipmentData
    {
        private readonly Dictionary<Equipment<T>, UpgradeComponent> _equipment = new();

        public void Add(Equipment<T> equipment)
        {
            if (_equipment.ContainsKey(equipment) == false)
            {
                _equipment.Add(equipment, equipment.Data.LevelData);
                equipment.Data.LevelData.Initialize(equipment.Data);
            }
        }

        public void Upgrade(Equipment<T> equipment)
        {
            var newLevel = equipment.Data.LevelData.ShowNext();

            if (newLevel.ForAll || equipment.Data.HasComponent(newLevel.Type) == false)
                foreach (var equip in _equipment.Keys)
                {
                    if (equip == equipment)
                        equip.Data.LevelData.LevelUp(newLevel);
                    equip.Data.GetComponent(newLevel.Type)?.ChangeValue(newLevel.Value, newLevel.IsPercent);
                }
            else
                _equipment[equipment].LevelUp(newLevel);
        }
    }
}
