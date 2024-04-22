using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MolecularSurvivors
{
    public class InventoryBlock : MonoBehaviour
    {
        private readonly List<InventorySlot> _slots = new();
        private readonly List<EquipmentData> _equipment = new();

        [SerializeField] private InventorySlot _slotTemplate;

        public void Initialize(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                var slot = Instantiate(_slotTemplate, transform);
                _slots.Add(slot);
            }
        }

        public void Add(EquipmentData equipment)
        {
            InventorySlot slot;

            if (_equipment.Contains(equipment))
                slot = _slots.FirstOrDefault(slot => slot.Equipment == equipment);
            else
            {
                slot = _slots.FirstOrDefault(slot => slot.Empty);
                _equipment.Add(equipment);
            }

            slot?.Set(equipment);
        }

        public IEnumerable<InventorySlot> GetEmptySlots() => _slots.Where(slot => slot.Empty);
    }
}