using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MolecularSurvivors
{
    public class InventoryBlock : MonoBehaviour
    {
        public List<InventorySlot> Slots { get; private set; } = new();
        private readonly List<EquipmentData> _equipment = new();

        [SerializeField] private InventorySlot _slotTemplate;

        public void Initialize(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                var slot = Instantiate(_slotTemplate, transform);
                Slots.Add(slot);
            }
        }

        public void Add(EquipmentData equipment)
        {
            switch (_equipment.Contains(equipment))
            {
                case true:
                    UpgradeExisting(equipment);
                    break;
                case false:
                    AddNew(equipment);
                    break;
                default:
                    throw new System.Exception("Unhandled case");
            }
        }

        public IEnumerable<InventorySlot> GetEmptySlots() => Slots.Where(slot => slot.Empty);

        private void AddNew(EquipmentData equipment)
        {
            _equipment.Add(equipment);
            var slot = Slots.FirstOrDefault(slot => slot.Empty);
            slot.Set(equipment);
        }

        private void UpgradeExisting(EquipmentData equipment)
        {
            var slot = Slots.FirstOrDefault(slot => slot.Equipment == equipment);
            slot.Set(equipment);
        }

        #region Old
        /* public bool HasEmptySlot() => _slots.FirstOrDefault(slot => slot.Empty) != null;

        public bool HasEquipment(EquipmentData equipment) => _equipment.Contains(equipment);

        public void Add(EquipmentData equipment)
        {
            InventorySlot slot;

            if (_equipment.Contains(equipment))
            {
                slot = _slots.FirstOrDefault(slot => slot.Equipment == equipment);

                if (Upgradables.Contains(equipment))
                    Upgradables.Remove(equipment);
            }
            else
            {
                _equipment.Add(equipment);
                if (equipment.LevelData.CanLevelUp)
                    Upgradables.Add(equipment);
                slot = _slots.FirstOrDefault(slot => slot.Empty);
            }

            if (slot != null)
                slot.Set(equipment);
        } */
        #endregion

    }
}