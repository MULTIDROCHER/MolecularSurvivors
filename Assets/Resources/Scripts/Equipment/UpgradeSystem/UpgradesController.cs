using System.Collections.Generic;

namespace MolecularSurvivors
{
    public class UpgradesController<T> where T : EquipmentData
    {
        private readonly EquipmentController<T> _controller;

        public UpgradesController(EquipmentController<T> controller) => _controller = controller;

        public void Upgrade(Equipment<T> equipment)
        {
            var newLevel = equipment.Data.LevelData.ShowNext();

            if (newLevel.ForAll || equipment.Data.HasComponent(newLevel.Type) == false)
                foreach (var equip in _controller.Equipment)
                {
                    if (equip == equipment)
                        equip.Data.LevelData.LevelUp(newLevel);
                    equip.Data.GetComponent(newLevel.Type)?.ChangeValue(newLevel.Value, newLevel.IsPercent);
                }
            else
                equipment.Data.LevelData.LevelUp(newLevel);
        }
    }
}
