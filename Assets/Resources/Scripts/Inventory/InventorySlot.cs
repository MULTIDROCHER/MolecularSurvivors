using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MolecularSurvivors
{
    public class InventorySlot : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _level;

        public EquipmentData Equipment{ get; private set; }

        public bool Empty { get; private set; } = true;

        public void Set(EquipmentData equipment)
        {
            switch (Equipment)
            {
                case null:
                    Add(equipment);
                    return;
                case var _ when Equipment == equipment:
                    Upgrade();
                    return;
                default:
                    Debug.Log("wtf");
                    return;
            }
        }

        private void Add(EquipmentData equipment)
        {
            Empty = false;
            Equipment = equipment;
            Upgrade();
            _image.sprite = equipment.Icon;
        }

        private void Upgrade()
        {
            _level.text = Equipment.LevelData.CurrentLevel + "/" + Equipment.LevelData.MaxLevel;
        }
    }
}