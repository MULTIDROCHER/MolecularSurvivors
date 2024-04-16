using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MolecularSurvivors
{
    public class UpgradesController<T> where T : EquipmentData
    {
        private EquipmentController<T> _controller;

        public UpgradesController(EquipmentController<T> controller) => _controller = controller;

        private readonly Dictionary<Equipment<T>, UpgradeComponent> _equipment = new();

        public void Add(Equipment<T> equipment)
        {
            if (_equipment.ContainsKey(equipment) == false)
            {
                equipment.Data.LevelData.Initialize(equipment.Data);
                _equipment.Add(equipment, equipment.Data.LevelData);
                Debug.Log($"{equipment.Data.TextData.Name} added to upgrades controller");
            }
        }

        public void Upgrade(Equipment<T> equipment)
        {
            Debug.Log($"{equipment.Data.TextData.Name} upgrades from upgrades controller");
            var newLevel = equipment.Data.LevelData.ShowNext();

            if (newLevel.ForAll || equipment.Data.HasComponent(newLevel.Type) == false)
                foreach (var equip in _controller.Equipment)
                    equip.Data.LevelData.LevelUp(newLevel);
            else
                _equipment[equipment].LevelUp(newLevel);
        }
    }
}
