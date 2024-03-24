using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MolecularSurvivors
{
    public class InventoryBlock : MonoBehaviour
    {
        private readonly List<InventorySlot> _slots = new();
        private readonly List<EquipmentData> _equipment = new();

        public void Initialize(InventorySlot template, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                var slot = Instantiate(template, transform);
                _slots.Add(slot);
            }
        }

        public bool HasEmptySlot() => _slots.FirstOrDefault(slot => slot.Empty) != null;

        public bool HasEquipment(EquipmentData equipment) => _equipment.Contains(equipment);

        public void Add(EquipmentData equipment)
        {
            InventorySlot slot;

            if (_equipment.Contains(equipment))
            {
                slot = _slots.FirstOrDefault(slot => slot.Equipment == equipment);
            }
            else
            {
                _equipment.Add(equipment);
                slot = _slots.FirstOrDefault(slot => slot.Empty);
            }

            if (slot != null)
                slot.Set(equipment);
        }
    }
}