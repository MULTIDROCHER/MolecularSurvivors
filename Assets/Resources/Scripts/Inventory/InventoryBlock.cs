using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MolecularSurvivors
{
    public class InventoryBlock : MonoBehaviour
    {
        private List<InventorySlot> _slots = new();
        private List<EquipmentData> _equipment = new();

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
            var slot = GetSlot();

            if (slot != null)
            {
                slot.Set(equipment);
                _equipment.Add(equipment);
            }
        }

        public InventorySlot GetSlot() => _slots.FirstOrDefault(slot => slot.Empty);
    }
}